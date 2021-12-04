import React, { useState } from 'react';
import { Button, Grid, Typography,
  Stepper, Step, StepLabel, Container, StepContent, Divider, Link, TextField, FormControlLabel, FormControl, Checkbox, Stack, Autocomplete, InputAdornment, FormHelperText, Input, InputLabel, Select, MenuItem, SelectChangeEvent } from '@mui/material';
import CancelIcon from '@mui/icons-material/Cancel';
// import NewSGeneralConn from '../../api-conn/new-general-conn';
// import NewSVariationsConn from '../../api-conn/new-variation-conn';
// import FullFeaturedCrudGrid from '../../components/form/data-grid';
import { Formato } from '../../models/formato';
import { Estilo } from '../../models/estilo';
import { Tecnica } from '../../models/tecnica';
import { Tema } from '../../models/tema';
import { Licencia } from '../../models/licencia';
import { Servicio } from '../../models/servicio';
import { ServicioVariacion } from '../../models/servicio_variacion';
import { ServicioCaracteristica } from '../../models/servicio_caracteristica';
import { CaracteristicaOpciones } from '../../models/caracteristica_opciones';
import { Duracion } from '../../models/duracion';
import { useNavigate } from 'react-router';
import { ListTema } from '../../api/apiTema';
import { ListFormato } from '../../api/apiFormato';
import { ListLicencia } from '../../api/apiLicencia';
import { ListEstilo } from '../../api/apiEstilo';
import { ListTecnica } from '../../api/apiTecnica';
import { useUser } from '../session/userContext';
import { CreateServicio } from '../../api/apiServicio';
import { CreateServicioTema } from '../../api/apiServicioTema';
import { CreateServicioFormato } from '../../api/apiServicioFormato';

function NewService(props:any) {
  const navi = useNavigate();
  const {user} = useUser();
  const {formato, refreshFormato} = ListFormato();
  const {estilo, refreshEstilo} = ListEstilo();
  const {licencia, refreshLicencia} = ListLicencia();
  const {tecnica, refreshTecnica} = ListTecnica();
  const {temas, refreshTemas} = ListTema();
  
  const defaultServ = {
    service: {
      nombre: "",
      artista_id: 0,
      duracion_esperada: {days:2},
      precio_base: 5,
      rating: 0,
      q_valoraciones: 0,
      es_virtual: true,
      porc_adelanto: 50,
      acepta_rembolso: false,
      estilo: new Estilo(),
      tecnica: new Tecnica(),
      acerca_servicio: "",
      licencia: licencia.length===0? new Licencia() : licencia[0],
      q_revisiones: 0, //q_reviciones
      url_img: "",
    },
    themes: new Array<Tema>(),
    formats: new Array<Formato>()
  };

  const [newServ, setNewServ] = useState(defaultServ);

  React.useEffect(() => {
    refreshFormato();
    refreshEstilo();
    refreshLicencia();
    refreshTecnica();
    refreshTemas();
    setNewServ({...newServ, service: {
      ...newServ.service,
      artista_id: user === undefined ? 0 : user.id,
      licencia: licencia[0],
      duracion_esperada: { ...newServ.service.duracion_esperada, days:4 },
    }});
  }, [temas.length===0])

  if (user === undefined || user.nombre_usuario===""){ // || 
    console.log("no está logueado");
    navi('/login', { replace: true });
    return <></>
  }
  
  const isOK = (check:any, isList?:boolean) => {
    //console.log(check);
    if (check === null || check === undefined
      || check === "" || check === -1 ) {
        return false;
      }
    if (isList && check.length === 0) { return false }
    return true;
  }
  const handlePost = () => {
    //enviar datos a la BD
    //console.log(isComplete);
    if( isOK(newServ.service.nombre)
    && isOK(newServ.themes,true)
    && isOK(newServ.formats,true)
    && isOK(newServ.service.estilo)
    && isOK(newServ.service.tecnica)
    && isOK(newServ.service.acerca_servicio)
    //&& isOK(servGral.chars) && isOK(servGral.chars?.options)
    //&& isOK(servGral.chars?.name)
    ){
      console.log('nuevo servicio',newServ);
      CreateServicio ({
        id: 0,
        nombre: newServ.service.nombre,
        artista_id: newServ.service.artista_id,
        duracion_esperada: {days:0},
        precio_base: newServ.service.precio_base,
        rating: 0,
        q_valoraciones: 0,
        es_virtual: newServ.service.es_virtual,
        porc_adelanto: newServ.service.porc_adelanto,
        acepta_rembolso: newServ.service.acepta_rembolso,
        estilo_id: newServ.service.estilo.id,
        tecnica_id: newServ.service.tecnica.id,
        acerca_servicio: newServ.service.acerca_servicio,
        licencia_id: newServ.service.licencia.id,
        q_revisiones: newServ.service.q_revisiones,
        url_imagen: newServ.service.url_img 
      });
      // CreateServicioTema( {tema_id: 0, servicio_id: 0} );
      // CreateServicioFormato( {formato_id: 0, servicio_id: 0} );
      //navi('/artist-profile', { replace: true });
    } else {
      console.log('nooo',newServ);
      console.log("uncomplete");
    }
  };

  return ( 
  <Container>
    <Grid container className="filter-up">
      <Grid item xs={6}>
        <Typography variant="h3">Publicar producto</Typography>
      </Grid>
      <Grid item xs={4}>
        <Link href="/artist-profile">
          <Button endIcon={<CancelIcon/>} variant="contained" color="error">
            Cancelar
          </Button>
        </Link>
      </Grid>
    </Grid>

    <br/><Divider/><br/><br/>

    <Grid container sx={{width: '50%', minWidth: '16rem', display:'flex',
    flexDirection:'column', rowGap:'2em', margin: '0px auto'}}>

    <TextField fullWidth id="nombre-servicio"
        label="Nombre del servicio" required
        onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
          newServ.service.nombre = event.target.value;
          setNewServ(newServ);
        }} />
     
    <FormControlLabel control={
      <Checkbox id="envio-digital" defaultChecked
          onChange={((event: any, checked: boolean)=>
            ()=>{
              newServ.service.es_virtual = checked;
              setNewServ(newServ);
          })}/>
        } label="Envío digital" />

    <FormControl required fullWidth>
          <Stack spacing={3}>
            <Autocomplete multiple id="formatos"
            options={formato} filterSelectedOptions
            getOptionLabel={(option) => option.nombre} 
            onChange={(event: any, newValue:Formato[]) => {
              newServ.formats = newValue;
              setNewServ(newServ);
            }}
            renderInput={(params) => (
              <TextField label="Formatos" placeholder="Formatos" {...params} />
            )} />
          </Stack>
        </FormControl>

        <FormControl fullWidth>
          <Autocomplete id="estilo" freeSolo
            options={estilo} value={newServ.service.estilo}
            getOptionLabel={
              (option) => typeof option === 'string' ?
              option : option.nombre
            }
            onChange={(event: any, newValue:Estilo|string|null) => {
              /*console.log(newValue,typeof newValue === 'object',
                typeof newValue, typeof newValue === 'string');*/
              if (newValue !== null){
                if ( typeof newValue === 'object' ) {
                  newServ.service.estilo = newValue;
                } else if (typeof newValue === 'string') {
                  newServ.service.estilo = {id:0, nombre:newValue};
                }
              }
              setNewServ(newServ);
            }}
            renderInput={(params) =>
              <TextField {...params} label="Estilo" />
          }/>
        </FormControl>
        
        <FormControl fullWidth>
          <Autocomplete id="técnica" freeSolo
            options={tecnica} value={newServ.service.tecnica}
            getOptionLabel={
              (option) => typeof option === 'string' ?
              option : option.nombre
            }
            onChange={(event: any, newValue:Tecnica|string|null) => {
              if (newValue !== null){
                if ( typeof newValue === 'object' ) {
                  newServ.service.tecnica = newValue;
                } else if (typeof newValue === 'string') {
                  newServ.service.tecnica = {id:0, nombre:newValue};
                }
              }
              setNewServ(newServ);
            }}
            renderInput={(params) =>
              <TextField {...params} label="Técnica" />
          }/>
        </FormControl>

        <FormControl required fullWidth>
          <Stack spacing={3}>
            <Autocomplete multiple id="temas" freeSolo
            options={temas} filterSelectedOptions
            value={newServ.themes}
            getOptionLabel={
              (option) => typeof option === 'string' ?
              option : option.nombre
            }
            onChange={(event: any, newValue:(string|Tema)[]) => {
              console.log('tema',newValue);
              if (typeof newValue === 'string'){
                setNewServ({...newServ, themes: [newValue]});
              }
              else {
                let newvals:Tema[] = [];
                newValue.map((nv)=>{
                  if (typeof nv === 'string') { newvals.push({id:0,nombre:nv})}
                  if (typeof nv === 'object') { newvals.push(nv); }
                });
                setNewServ({...newServ, themes: newvals});
              }
            }}
            renderInput={(params) => (
              <TextField label="Temas" placeholder="Temas" {...params} />
            )} />
          </Stack>
        </FormControl>

        <TextField id="acerca-de" label="Acerca del servicio"
        fullWidth multiline maxRows={8}
        onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
          newServ.service.acerca_servicio = event.target.value;
          setNewServ(newServ);
        }}/>

        <FormControl required> 
          <FormHelperText id="duracion-esperada-label"> Duración esperada </FormHelperText>
          <Input id="duracion-esperada" defaultValue={2} type="number"
            endAdornment={<InputAdornment position="end">
              <strong>días</strong></InputAdornment>}
            aria-describedby="duracion-esperada"
            inputProps={{ 'aria-label': 'duracion-esperada-lbl', }}
          onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
            newServ.service.duracion_esperada.days = +event.target.value;
            setNewServ(newServ);
          }}/>
        </FormControl>
          
        <div style={{ display:'flex', columnGap:'2rem'}}>
        <FormControl required> 
          <FormHelperText id="precio-base-label"> Precio base </FormHelperText>
          <Input id="precio-base" defaultValue={5} type="number"
            endAdornment={<InputAdornment position="end">
              <strong>$</strong></InputAdornment>}
            aria-describedby="precio-base"
            inputProps={{ 'aria-label': 'precio-base-lbl', }}
          onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
            newServ.service.precio_base = +event.target.value;
            setNewServ(newServ);
          }}/>
        </FormControl>
          
        <FormControl required> 
          <FormHelperText id="porc-adelanto-label"> Porcentaje de adelanto </FormHelperText>
          <Input id="porc-adelanto" defaultValue={50} type="number"
            endAdornment={<InputAdornment position="end">
              <strong>%</strong></InputAdornment>}
            aria-describedby="porcentaje-adelanto"
            inputProps={{ 'aria-label': 'porc-adelanto-lbl', }}
          onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
            newServ.service.porc_adelanto = +event.target.value;
            setNewServ(newServ);
          }}/>
        </FormControl>
        </div>
 
        <FormControlLabel control={
          <Checkbox id="reembolsable"
          onChange={(event:any, checked:boolean)=>{
            newServ.service.acepta_rembolso = checked;
            setNewServ(newServ);
          }}/>
        } label="Acepta reembolso" /> 

        <FormControl required fullWidth>
          <InputLabel id="licencia-label">Licencia</InputLabel>
          <Select labelId="licencia-label" id="licencias"
          label="Licencias" defaultChecked defaultValue={licencia[0]}
          value={newServ.service.licencia}
          onChange={(event: SelectChangeEvent<Licencia>) => {
            if (typeof event.target.value !== "string"){ //service
              setNewServ({...newServ, service:{...newServ.service, licencia: event.target.value}});
          };
          }}>
            {licencia.map((c)=>{return(
              <MenuItem value={c.id}>{c.nombre}</MenuItem>
            )})}
          </Select>
        </FormControl>
        
        <TextField fullWidth id="q-revisiones" type="number" defaultValue={3}
        label="Cantidad de revisiones sin costo adicional" required
        onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
          newServ.service.q_revisiones = +event.target.value;
          setNewServ(newServ);
        }}/>
        
        <TextField fullWidth id="img_url" type="url"
        label="URL de la imagen del servicio" required
        onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
          setNewServ({...newServ, service: {...newServ.service, 
          url_img: event.target.value}});
        }}/>


      <br/><br/>
      <Button onClick={handlePost}> Publicar </Button>
    </Grid>

  </Container>
  )
};
export default NewService;
