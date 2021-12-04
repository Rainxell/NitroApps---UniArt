import React from 'react'
import { Button, Container, Divider, Grid, Link, Paper, Typography } from '@mui/material';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import { themeMui, blacks, whites } from '../../themes/theme-mui';
import ListItemText from '@mui/material/ListItemText';
import CheckIcon from '@mui/icons-material/Check';
import AddIcon from '@mui/icons-material/Add';
import ForumTTIcon from '@mui/icons-material/ForumTwoTone';
import AssessmentTTIcon from '@mui/icons-material/AssessmentTwoTone';
import FactCheckTTIcon from '@mui/icons-material/FactCheckTwoTone';
import Footer from '../../components/dashboard/footer';
import ArtistCards from '../../components/card-custom/artist-cards';
import ServiceCards from '../../components/card-custom/service-cards';
import { useUser } from '../session/userContext';


function LandingPage() {

  //const {user, signup} = useUser();

  // React.useEffect(()=>{
  //   console.log('desde landng', user);
  // },[]);

  const btnDBGStyle = {
    backgroundColor: whites.main,
    color: blacks.main,
    '&:hover': {backgroundColor:whites.light,}
  };

  return (
    <>
    <Container style={{
      backgroundImage: "linear-gradient(270deg, "+themeMui.palette.primary.main
                      +" 0%, transparent 100%), url('"+process.env.PUBLIC_URL + "/images/bgs/portada.png')",
      backgroundAttachment: "fixed",
    }}>
      <Grid container spacing={2}>
        <Grid item xs={1}/>
        <Grid item xs={6}>
          <Paper elevation={1}
          style={{backgroundColor: blacks.main, color: whites.main, padding:"2em 3em",}}>
            <Typography component="h1">
            <strong style={{fontSize:"3em", lineHeight:"1em",}}>UNIFICANDO PASIONES Y EMPRENDIMIENTOS.</strong>
            </Typography>
            <br/>
            <Typography component="strong">
              Únete a nuestra comunidad de artistas y emprendedores y podrás:
            </Typography>
            <br/><br/>
            <List>
              <ListItem>
                <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
                <ListItemText primary="Ver el progreso y estado de tus solicitudes de servicios" />
              </ListItem>
              <ListItem>
                <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
                <ListItemText primary="Comunicarte diréctamente con el artista comisionado" />
              </ListItem>
              <ListItem>
                <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
                <ListItemText primary="Encontrar artistas independientes variados" />
              </ListItem>
              <ListItem>
                <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
                <ListItemText primary="ncontrar eficazmente el servicio artístico que buscas" />
              </ListItem>
            </List>
          </Paper>
        </Grid>
        <Grid item xs={4}>
          <img alt="background" src={process.env.PUBLIC_URL + "/images/icon_BIG.svg"}/>
        </Grid>
        <Grid item xs={1}/>
      </Grid>
    </Container>

    <Container style={{
      backgroundColor: themeMui.palette.secondary.main,
      color: themeMui.palette.secondary.contrastText,
      }}>
      <Typography variant="h1" component="h1">Servicios más populares</Typography>
      <br/>
      <ServiceCards/>
      <br/>
      <Link href="/explore"><Button sx={btnDBGStyle}>Descubrir más</Button></Link>
    </Container>

    <Container style={{
      backgroundColor: themeMui.palette.primary.main,
      color: themeMui.palette.primary.contrastText,
      }}>
      <Typography variant="h1" component="h1">¡Artistas en estreno!</Typography>
      <br/>
      <ArtistCards/>
      <br/>
      <Button sx={btnDBGStyle}>Descubrir más</Button>
    </Container>

    <Container>
      <Typography variant="h1"> LO QUE MÁS REQUIERES PARA UN BUEN FREELO ARTÍSTICO: </Typography>
      <br/><br/>
      <Grid container spacing={1} >
        <Grid item xs={2}>
          <ForumTTIcon style={{fontSize:"6em",}}/><br/>Comunicación
        </Grid>
        <Grid item xs={1}><AddIcon style={{fontSize:"2em",}}/></Grid>
        <Grid item xs={2}>
          <AssessmentTTIcon style={{fontSize:"6em",}}/><br/>Organización
        </Grid>
        <Grid item xs={1}><AddIcon style={{fontSize:"2em",}}/></Grid>
        <Grid item xs={2}>
          <FactCheckTTIcon style={{fontSize:"6em",}}/><br/>Eficacia
        </Grid>
      </Grid>
      <br/><br/><br/>
      <Grid container spacing={1}>
        <Grid item xs={5}>
          <Typography variant="h2" color="secondary">EMPRENDEDORES TALENTOSOS</Typography>
        </Grid>
        <Grid item xs={2}><AddIcon style={{fontSize:"4em",}}/></Grid>
        <Grid item xs={5}>
          <Typography variant="h2" color="primary">ARTISTAS INDEPENDIENTES</Typography>
        </Grid>
      </Grid>
      <br/>
    </Container>

    <Container style={{backgroundColor: blacks.main, color: whites.main,}}>
      <Typography variant="h1"> ¿Cómo lo logramos? </Typography>
      <br/>
      <Grid container spacing={1}>
        <Grid item xs={4}>
          <Typography variant="h4" component="h2">Comunicación</Typography>
          <List>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Comunicarte diréctamente con el artista comisionado." />
            </ListItem>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Conoce más del artista visitando sus otras redes sociales desde su perfil." />
            </ListItem>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Elige entre diferentes características del servicio ofrecido, ¡e incluso incluye referencias! Todo para mantener una misma idea del servicio final." />
            </ListItem>
          </List>
        </Grid>
        <Grid item xs={8}>
        <img alt="background" src={process.env.PUBLIC_URL + "/images/landing/screens_communication.png"}/>
        </Grid>
      </Grid>
      <br/><Divider/><br/>
      <Grid container spacing={1}>
        <Grid item xs={4}>
          <Typography variant="h4" component="h2">Organización</Typography>
          <List>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Manténte al tanto del progreso de las artes solicitadas mediante el tablero de historial." />
            </ListItem>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Filtra las comisiones realizadas, en progreso. y verifica los servicios próntos a entregarse." />
            </ListItem>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Cuando un artista realiza un avane en el proyecto, podrás verificarlo desde tu historial." />
            </ListItem>
          </List>
        </Grid>
        <Grid item xs={8}>
        <img alt="background" src={process.env.PUBLIC_URL + "/images/landing/screens_organization.png"}/>
        </Grid>
      </Grid>
      <br/><Divider/><br/>
      <Grid container spacing={1}>
        <Grid item xs={4}>
          <Typography variant="h4" component="h2">Eficacia</Typography>
          <List>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Filtra detalladamente el servicio que estás buscando." />
            </ListItem>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Brinda un primer alcance detallado al artista y ahorra tiempo." />
            </ListItem>
            <ListItem>
              <ListItemIcon> <CheckIcon color="info"/> </ListItemIcon>
              <ListItemText primary="Observa los avances y comunica las observaciones por cada revisión." />
            </ListItem>
          </List>
        </Grid>
        <Grid item xs={8}>
        <img alt="background" src={process.env.PUBLIC_URL + "/images/landing/screens_efficacy.png"}/>
        </Grid>
      </Grid>
    </Container>

    <Container style={{
      backgroundColor: themeMui.palette.info.main,
      paddingTop: "8rem",
      paddingBottom: "8rem",
    }}>
      <img alt="coffetti" src={process.env.PUBLIC_URL + "/images/bgs/coffetti.svg"}/>
      <Typography variant="h1"> ¡ÚNETE A LA COMUNIDAD! </Typography>
      <Button variant="contained" color="primary">Descubrir más</Button>
      <img alt="coffetti" src={process.env.PUBLIC_URL + "/images/bgs/coffetti.svg"}/>
    </Container>

    
    <Footer/>
  </>
  );
};

export default LandingPage;
