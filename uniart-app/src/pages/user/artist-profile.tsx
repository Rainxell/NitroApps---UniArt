import React, { useEffect } from 'react';
import { Avatar, Divider,
  Container, Grid, Paper,
  FormControl, InputLabel, Button,
  Select, SelectChangeEvent, 
  ListItem, ListItemIcon, ListItemText,
  MenuItem, Rating, Typography, ButtonBase, Link } from '@mui/material';
import { blacks } from '../../themes/theme-mui';
import { Artista } from '../../models/artista';
import { RedSocial } from '../../models/red_social';
import { Tema } from '../../models/tema';
import RoomIcon from '@mui/icons-material/Room';
import StarIcon from '@mui/icons-material/Star';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Footer from '../../components/dashboard/footer';
import ServiceCards from '../../components/card-custom/service-cards';
import ReviewCardsConn from '../../api-conn/review-cards-conn';
import { useUser } from '../session/userContext';
import { useNavigate, useParams } from 'react-router';
import apiArtista, { GetArtistaUsername } from '../../api/apiArtista';
import { ListRedesSociales } from '../../api/apiRedes_Sociales';
import { ListTema } from '../../api/apiTema';
import { dateToStr } from '../../utils/dateFx';
//import Box from '@mui/material/Box';



function ArtistProfile(props:any) { //{artist:Artista}

  let auxartist:Artista = new Artista();
  auxartist.nombre_usuario = "";
  auxartist.ciudad_id = 1;
  auxartist.rating = 4;
  auxartist.descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore, sed do eiusmod tempor.";
  auxartist.fecha_registro = new Date();
  //console.log(artist.fecha_registro.toString());

  const {username} = useParams(); //cambia el username del router en path... :username
  const {user} = useUser();
  const navi = useNavigate();
  const today = new Date();
  const {artistaBUN,refreshArtistaBUN} = GetArtistaUsername(username===undefined?"":username);
  //const [artista, setArtista] = React.useState<Artista>(auxartist);  
  const {redes, refreshRedesSociales} = ListRedesSociales();
  const {temas, refreshTemas} = ListTema();

  useEffect(() => {
    console.log('us',user,'uname',username);
  }, []);
  
  useEffect(()=>{
    refreshArtistaBUN();
  },[artistaBUN === undefined]);

  useEffect(()=>{
    if (artistaBUN !== undefined && 
      artistaBUN.nombre_usuario === ''){
      console.log('usuario no encontrado');
      navi("/explore", { replace: true });
    }
    //en getArtista debería enviar username
    //alert(artista.nombre_usuario);
    // apiArtista.detail(+username).then((res)=>{
    //   setArtista(res);
    // }).catch( ()=>{"no mostró artista"} );
    refreshTemas();
    refreshRedesSociales();
  },[temas.length === 0]);
  // React.useEffect(()=>{
  //   console.log('art...',artista);
  //   setArtista(artista);
  // },[JSON.stringify(artista)]);

  const isOwner = (user === undefined || user === null || artistaBUN === undefined ?
                false : (user.nombre_usuario === artistaBUN.nombre_usuario?
                true : false));
  let urlPortada = `${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg`;
  if ( artistaBUN !== undefined &&  artistaBUN.url_foto_portada !== '' ) {
    urlPortada = artistaBUN.url_foto_portada;
  }
  
  /*let temas: Tema[] = [
    {id: 0, nombre: "Concept Art"},
    {id: 0, nombre: "Fondos"},
    {id: 0, nombre: "Personakes"},
  ];*/ 

  
  const [orderbyS, setOrderbyS] = React.useState('1');
  const handleChangeOBS = (event: SelectChangeEvent) => {
    setOrderbyS(event.target.value);
  };
  const [orderbyR, setOrderbyR] = React.useState('1');
  const handleChangeOBR = (event: SelectChangeEvent) => {
    setOrderbyR(event.target.value);
  };
  
  return (
    <>
    <Container sx={{
      backgroundColor: blacks.main,
      backgroundImage: `url("${urlPortada}")`,
      backgroundAttachment: "fixed",
      backgroundPosition: 'center',
      height: "12em",
    }}></Container>
    
    <Grid container spacing={2} sx={{padding:"1em 2em", alignItems: "flex-start", }}>
      <Grid item xs={3}>
        <Paper sx={{ backgroundColor: "transparent", textAlign: "left",
          marginTop: "-1rem", padding:"0.5rem",}}>
            
          <Grid container spacing={2} >
            <Grid item xs={4} >
              <Avatar alt={artistaBUN?.nombre_usuario}
              src={artistaBUN?.url_foto_perfil}
              sx={{ width: "5rem", height:"5rem",
                marginTop: "-2em", marginLeft:"-0.5em"}}/>
            </Grid>
            <Grid item xs={8}>
              <Grid container spacing={1} >
                <Grid item xs={12}>
                  <Typography variant="h4">{artistaBUN?.nombre_usuario}</Typography>
                </Grid>
                <Grid item xs={12}>
                  <ListItem>
                    {artistaBUN?.rating === 0? <></> :<>
                    <ListItemIcon><Rating value={artistaBUN?.rating} readOnly/></ListItemIcon>
                    <ListItemText primary={`${artistaBUN?.rating} (${artistaBUN?.q_valoraciones})`} />
                    </>}
                  </ListItem>
                </Grid>
              </Grid>
            </Grid>

            <Grid item xs={12} >
              <Typography component="p">{artistaBUN?.descripcion}</Typography>
              <br/>
                  <ListItem>
                    <ListItemIcon><RoomIcon color="secondary"/></ListItemIcon>
                    <ListItemText primary={artistaBUN?.ciudad_id} />
                  </ListItem>
                  <br/>
              <Typography component="p">
                Se unió {
                  artistaBUN?.fecha_registro === undefined? dateToStr(today) 
                  : dateToStr(artistaBUN?.fecha_registro)
                }
              </Typography>

              <br/> <Divider/> <br/>

              <Typography component="p" style={{marginBottom: "0.5em"}}>
                <strong>Servicios</strong>
              </Typography>
              <ListItem>
                <ListItemText>En Oferta</ListItemText>
                <ListItemIcon>0</ListItemIcon>
              </ListItem>
              { temas.map((t)=>{
                return (
                  <ListItem>
                    <ListItemText>{t.nombre}</ListItemText>
                    <ListItemIcon>0</ListItemIcon>
                  </ListItem>
                );
              }) }
                
              <br/> <Divider/> <br/>

              <Grid item xs={12}>
                <Button variant="outlined" color="secondary">Ver políticas generales del servicio</Button>
                <Button variant="outlined" color="secondary">Ver preguntas frecuentes</Button>
              </Grid>

              </Grid>

          </Grid>
        </Paper>
        
      </Grid>
      <Grid item xs={9}>
        <Grid container spacing={2} sx={{padding:"1em 2em"}}>

          <Grid item xs={6}>
            <strong>Servicios</strong>
          </Grid>
          {isOwner?
          <Grid item xs={3}>
            <Link href="/new-service" underline="none">
              <Button variant="contained" endIcon={<AddCircleIcon/>}>
                Publicar
              </Button>
            </Link>
          </Grid>
          : <></> }
          <Grid item xs={3} sx={{display: "flex", justifyContent: "flex-end",}}>
            <FormControl >
              <InputLabel id="order-by-label">Ordenar por</InputLabel>
              <Select labelId="order-by-label" id="order-by" 
                value={orderbyS} onChange={handleChangeOBS} label="Más recientes" >
                <MenuItem value={"1"}>Más recientes</MenuItem>
                <MenuItem value={"2"}>Más antiguos</MenuItem>
                <MenuItem value={"3"}>Más económicos</MenuItem>
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={12}>
            <ServiceCards/>
          </Grid>

          <Grid item xs={12}> <Divider/>  </Grid>

          <Grid container className="filter-up">
            <ListItem>
              <ListItemText><strong>Reseñas como vendedor</strong></ListItemText>
              <StarIcon color="info"/>{artistaBUN?.rating} ({artistaBUN?.q_valoraciones})
            </ListItem>

            <FormControl >
              <InputLabel id="order-by-label">Ordenar por</InputLabel>
              <Select labelId="order-by-label" id="order-by" 
                value={orderbyR} onChange={handleChangeOBR} label="Más recientes" >
                <MenuItem value={"3"}>Más relevantes</MenuItem>
                <MenuItem value={"1"}>Más recientes</MenuItem>
                <MenuItem value={"2"}>Más antiguos</MenuItem>
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs={12}>
            <ReviewCardsConn/>
          </Grid>

        </Grid>
      </Grid>
    </Grid>
    
    <Footer />
    </>
  );
};

export default ArtistProfile;
