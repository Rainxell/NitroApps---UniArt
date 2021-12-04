import React from 'react';
import { Formato } from '../../models/formato';
import { Estilo } from '../../models/estilo';
import { Tecnica } from '../../models/tecnica';
import { Tema } from '../../models/tema';
import { Licencia } from '../../models/licencia';
import { Button, Grid, Typography,
  TextField, Select, FormControl,
  InputLabel, MenuItem, Checkbox, FormControlLabel,
  Stack, Autocomplete, InputAdornment, FormHelperText, Input, SelectChangeEvent, Divider }
  from '@mui/material';
import ListItemChips from '../../components/form/list-item-chips';
import { useNavigate } from "react-router-dom";


//si su id es -1 son nuevos elementos
interface ServGralProps {
  name?: string,
  send_digital: boolean,
  formats?: Formato[],
  style?: Estilo | string,
  technique?: Tecnica,
  themes?: Tema[],
  about?: string,
  porc_prev: number,
  refoundable: boolean,
  licence?: number,
  qchecks: number,
  chars?: {name:string, options:string[]},
}

const defaults: ServGralProps = {
  send_digital: true,
  porc_prev: 50,
  refoundable: false,
  licence: 0,
  qchecks: 3,
};

const NewSGeneral = ( props:{ id?:string,
  formatos:Formato[], estilos:Estilo[],
  tecnicas:Tecnica[], temas:Tema[], licencias:Licencia[]} ) => {

  const [servGral,setServGral] = React.useState(defaults);
  //const [isComplete,setIsComplete] = React.useState(-1);
  //handleDelete = (chipToDelete: ChipData) => () => {}
  const maxChars = 5;
  const isOK = (check:any, isList?:boolean) => {
    //console.log(check);
    if (check === null || check === undefined
      || check === "" || check === -1 ) {
        return false;
      }
    if (isList && check.length === 0) { return false }
    return true;
  }
  
  const navi = useNavigate();
  const handleNext = () => {
    //enviar datos a la BD
    //console.log(isComplete);
    if( isOK(servGral.name) && isOK(servGral.formats,true)
    && isOK(servGral.style) && isOK(servGral.technique)
    && isOK(servGral.themes,true) && isOK(servGral.about)
    //&& isOK(servGral.chars) && isOK(servGral.chars?.options)
    //&& isOK(servGral.chars?.name)
    ){
      console.log('ok',servGral);
      navi('/artist-profile', { replace: true });
    } else {
      console.log('nooo',servGral);
      console.log("uncomplete");
    }
  };
  
  return (<>
    <Grid container spacing={12} sx={{alignItems: "flex-start"}} id={props.id}>
      <Grid item xs={4} sx={{ display:"flex", alignItems:"flex-start",
        flexDirection:"column", rowGap:"1.5rem", }}>
        <Typography variant="h4"> Características generales </Typography>
        
        <TextField fullWidth id="nombre-servicio"
        label="Nombre del servicio" required
        onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
          servGral.name = event.target.value;
          setServGral(servGral);
        }} />
        
        <FormControlLabel control={
          <Checkbox id="envio-digital" defaultChecked
          onChange={((event: any, checked: boolean)=>
            ()=>{
              servGral.send_digital = checked;
              setServGral(servGral);
          })}/>
        } label="Envío digital" />

        <FormControl required fullWidth>
          <Stack spacing={3}>
            <Autocomplete multiple id="formatos"
            options={props.formatos} filterSelectedOptions
            getOptionLabel={(option) => option.nombre} 
            onChange={(event: any, newValue:Formato[]) => {
              servGral.formats = newValue;
              setServGral(servGral);
            }}
            renderInput={(params) => (
              <TextField label="Formatos" placeholder="Formatos" {...params} />
            )} />
          </Stack>
        </FormControl>
        
        <FormControl fullWidth>
          <Autocomplete id="estilo" freeSolo
            options={props.estilos} value={servGral.style}
            getOptionLabel={
              (option) => typeof option === 'string' ?
              option : option.nombre
            }
            onChange={(event: any, newValue:Estilo|string|null) => {
              /*console.log(newValue,typeof newValue === 'object',
                typeof newValue, typeof newValue === 'string');*/
              if (newValue !== null){
                if ( typeof newValue === 'object' ) {
                  servGral.style = newValue;
                } else if (typeof newValue === 'string') {
                  servGral.style = {id:-1, nombre:newValue};
                }
              }
              setServGral(servGral);
            }}
            renderInput={(params) =>
              <TextField {...params} label="Estilo" />
          }/>
        </FormControl>
        
        <FormControl fullWidth>
          <Autocomplete id="técnica" freeSolo
            options={props.tecnicas} value={servGral.technique}
            getOptionLabel={
              (option) => typeof option === 'string' ?
              option : option.nombre
            }
            onChange={(event: any, newValue:Tecnica|string|null) => {
              if (newValue !== null){
                if ( typeof newValue === 'object' ) {
                  servGral.technique = newValue;
                } else if (typeof newValue === 'string') {
                  servGral.technique = {id:-1, nombre:newValue};
                }
              }
              setServGral(servGral);
            }}
            renderInput={(params) =>
              <TextField {...params} label="Técnica" />
          }/>
        </FormControl>

        <FormControl required fullWidth>
          <Stack spacing={3}>
            <Autocomplete multiple id="temas" freeSolo
            options={props.temas} filterSelectedOptions
            value={servGral.themes}
            getOptionLabel={
              (option) => typeof option === 'string' ?
              option : option.nombre
            }
            onChange={(event: any, newValue:(string|Tema)[]) => {
              console.log('tema',newValue);
              if (typeof newValue === 'string'){
                servGral.themes = [newValue];
                setServGral(servGral);
              }
              else {
                let newvals:Tema[] = [];
                newValue.map((nv)=>{
                  if (typeof nv === 'string') { newvals.push({id:-1,nombre:nv})}
                  if (typeof nv === 'object') { newvals.push(nv); }
                });
                servGral.themes = newvals;
                setServGral(servGral);
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
          servGral.about = event.target.value;
          setServGral(servGral);
        }}/>
          
        <FormControl required> 
          <FormHelperText id="porc-adelanto-label"> Porcentaje de adelanto </FormHelperText>
          <Input id="porc-adelanto" defaultValue={50} type="number"
            endAdornment={<InputAdornment position="end">
              <strong>%</strong></InputAdornment>}
            aria-describedby="porcentaje-adelanto"
            inputProps={{ 'aria-label': 'porc-adelanto-lbl', }}
          onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
            servGral.porc_prev = +event.target.value;
            setServGral(servGral);
          }}/>
        </FormControl>

        <FormControlLabel control={
          <Checkbox id="reembolsable"
          onChange={(event:any, checked:boolean)=>{
            servGral.refoundable = checked;
            setServGral(servGral);
          }}/>
        } label="Acepta reembolso" />

        <FormControl required fullWidth>
          <InputLabel id="licencia-label">Licencia</InputLabel>
          <Select labelId="licencia-label" id="licencias"
          label="Licencias" defaultChecked value={servGral.licence}
          onChange={(event: SelectChangeEvent<number>) => {
            if (typeof event.target.value === 'number'){
              servGral.licence = event.target.value;
              setServGral(servGral);
            }
          }}>
            {props.licencias.map((c)=>{return(
              <MenuItem value={c.id}>{c.nombre}</MenuItem>
            )})}
          </Select>
        </FormControl>
        
        <TextField fullWidth id="q-revisiones" type="number" defaultValue={3}
        label="Cantidad de revisiones sin costo adicional" required
        onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
          servGral.qchecks = +event.target.value;
          setServGral(servGral);
        }}/>
      </Grid>

      <Grid item xs={5} sx={{ display:"flex", alignItems:"flex-start",
        flexDirection:"column", rowGap:"1.5rem", }}>
        <Typography variant="h4"> Variaciones de producto </Typography>
        <Typography component="p" >Características (mínimo 1, máximo 5)</Typography>
        <Typography component="p" >* Cada característica debe tener mínimo 1 opción, máximo 5) </Typography>
        
        <ListItemChips maxParents={maxChars} maxChilds={maxChars}
          labelParent={"Característica"} labelChilds={"Opciones de Característica"}/>
      </Grid>


    </Grid>
    
      <br/> <Divider/> <br/><br/>
      <Button onClick={handleNext} variant="contained">
        Siguiente
      </Button>
  </>);
};

export default NewSGeneral;
