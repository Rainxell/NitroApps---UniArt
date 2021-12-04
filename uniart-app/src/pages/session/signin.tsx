import React, { ReactEventHandler, useState } from 'react';
import { useNavigate } from 'react-router';
import { useUser } from './userContext';
import Footer from '../../components/dashboard/footer';
import { Button, ButtonBase, Container, FormControl, Grid, InputLabel, Link, MenuItem, Select, SelectChangeEvent, TextField, Typography } from '@mui/material';
import { blacks, themeMui, whites } from '../../themes/theme-mui';
import { Box, styled } from '@mui/system';
//import { Usuario } from '../../models/usuario';
import { Artista } from '../../models/artista';
import CountryCity from '../../components/form/country-city';
//import { CreateUsuario } from "../../api/apiUsuario";

let defaulArtist = new Artista();
defaulArtist.ciudad_id = 1610; //LIMA

const Signin = () => {
  const {user, signup} = useUser();
  const navi = useNavigate();
  const [ isArtist, setIsArtist ] = useState(true);
  const [ newUser, setNewUser ] = useState(defaulArtist);
  const [city, setCity] = useState(0);

  React.useEffect(()=>{
    console.log(city);
    setNewUser({...newUser,ciudad_id:city});
  },[city]);
  
  if (user !== undefined && user.nombre_usuario!=""){ // || 
    console.log(user);
    navi('/', { replace: true });
    return <></>
  }

  const avatarsPred = [
    "https://pbs.twimg.com/media/FEwk6p4XsAYlQmZ?format=png&name=small",
    "https://pbs.twimg.com/media/FEwk6p6WUAA86l4?format=png&name=small",
    "https://pbs.twimg.com/media/FEwk6p5X0AQ_Qf-?format=png&name=small",
    "https://pbs.twimg.com/media/FEwk6p5XMAMnRHX?format=png&name=small",
    "https://pbs.twimg.com/media/FEwlDKGWYAM5Qy0?format=png&name=small",
    "https://pbs.twimg.com/media/FEwlDKwXsAMvz05?format=png&name=small",
    "https://pbs.twimg.com/media/FEwlDLBXMAwAzHB?format=png&name=small",
    "https://pbs.twimg.com/media/FEwlAInWYAkd3si?format=png&name=small",
    "https://pbs.twimg.com/media/FEwlAI7WUAIOxqB?format=png&name=small",
    "https://pbs.twimg.com/media/FEwlAJxX0A4KrQa?format=png&name=small"
  ];
  
  const handleSignIn = () => {
    console.log('creando a...',newUser);
    if (newUser.nombre_usuario === "" ||
        newUser.password === "" ||
        newUser.email === "" ||
        newUser.nombre === "" ||
        newUser.apellido === "" //||
        //newUser.ciudad_id === 0
    ) {
      alert("datos incompletos");
      return;
    }
    if ( newUser.url_foto_perfil === "" ) {
      const randpos = Math.random() * (avatarsPred.length -1);
      newUser.url_foto_perfil = avatarsPred[randpos];
    }
    if (isArtist && newUser.descripcion === "" ){
      alert("Completar descripción");
      return; 
    }
    signup(newUser,isArtist);
    navi('/', { replace: true });
  };


  const UTypeButton = styled(ButtonBase)(({ theme }) => ({
    position: 'relative',
    height: '8em',
    width: '50%',
    padding: '1em 2em',
    rowGap: '1.5em',
    backgroundColor: whites.light,
    [theme.breakpoints.down('sm')]: {
      width: '100% !important', // Overrides inline-style
      height: 100,
    },
  }));
  const UTBtnDesc = styled('div')(({ theme }) => ({
    display: 'flex',
    flexDirection: 'column',
    rowGap: '1em'
  }));
  const UTBtnSvg = styled('svg')(({ theme }) => ({
    fill: blacks.light,
    height: '5em',
    width: '5em',
    marginRight: '1em',
    transition: 'fill 2s',
  }));

  const artistDataJsx = ()=>{
    return (<>
    <TextField id="descripcion" label="Descripción" required type="email"
    value={newUser.descripcion} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewUser({...newUser, descripcion:event.target.value });
      }
    }/>
    <TextField id="foto_portada" label="URL de foto de portada"
    value={newUser.url_foto_portada} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewUser({...newUser, url_foto_portada:event.target.value });
      }
    }/>
    </>);
    // url_foto_perfil: string = "";
    // url_foto_portada: string = `${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg`;
  }

  return (
    <>
    <Container maxWidth={"xs"} sx={{
      display:"flex", flexDirection:"column",
      rowGap:"1em", 
    }}>
    
    <img src={`${process.env.PUBLIC_URL}/images/logo_full.svg`}/> 
    <Box sx={{width: 'calc(100% + 8em)', marginLeft: '-4em'}}>
      <UTypeButton onClick={()=>{setIsArtist(false)}}>
        <UTBtnSvg>
          <path fill={isArtist?blacks.light:themeMui.palette.secondary.main}
          d="M36 0V42C36 51.9 27.9 60 18 60C8.1 60 0 51.9 0 42V0H12V42C12 45.3 14.7 48 18 48C21.3 48 24 45.3 24 42V0H36Z"/>
        </UTBtnSvg>
        <UTBtnDesc>
          <Typography variant="h5" color={isArtist?'silver':'secondary'}>
            Cuenta de Usuario
          </Typography>
          <Typography component="p">
            Encuentra y compra el arte que gustes.
          </Typography>
        </UTBtnDesc>
      </UTypeButton>
      <UTypeButton onClick={()=>{setIsArtist(true)}}>
        <UTBtnSvg>
          <path fill={isArtist?themeMui.palette.primary.main:blacks.light}
          d="M36 18V60H24V36H12V60H0V18C0 8.1 8.1 0 18 0C27.9 0 36 8.1 36 18ZM24 24V18C24 14.7 21.3 12 18 12C14.7 12 12 14.7 12 18V24H24Z"/>
        </UTBtnSvg>
        <UTBtnDesc>
          <Typography variant="h5" color={isArtist?'primary':'silver'}>
            Cuenta de artista
          </Typography>
          <Typography component="p">
            Vende tus creaciones personalizadas.
          </Typography>
        </UTBtnDesc>
      </UTypeButton>
    </Box>

    <TextField id="username" label="Nombre de usuario" required
    value={newUser.nombre_usuario} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewUser({...newUser, nombre_usuario:event.target.value });
      }
    }/>
    <TextField id="password" label="Contraseña" required type="password"
    value={newUser.password} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewUser({...newUser, password:event.target.value });
      }
    }/>
    <TextField id="email" label="Correo electrónico" required type="email"
    value={newUser.email} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewUser({...newUser, email:event.target.value });
      }
    }/>
    <TextField id="nombre" label="Nombres" required
    value={newUser.nombre} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewUser({...newUser, nombre:event.target.value });
      }
    }/>
    <TextField id="apellidos" label="Apellidos" required
    value={newUser.apellido} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewUser({...newUser, apellido:event.target.value });
      }
    }/>
    <TextField id="foto_perfil" label="URL de foto de perfil"
    value={newUser.url_foto_perfil} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setNewUser({...newUser, url_foto_perfil:event.target.value });
      }
    }/>
    
    <CountryCity city={city} setCity={setCity} />

    {isArtist ? artistDataJsx() : <></>}
    
    <br/>
    <Button variant="contained" onClick={handleSignIn}>
      Unirme
    </Button>
    <br/><br/>
    
    <div>
      <small>Al unirme, acepto los términos y condiciones del uso de esta plataforma.</small>
      <br/><br/>
      ¿Ya tienes una cuenta?
      <br/><br/>
      <Link href="/login">
        <Button>Iniciar sesión</Button>
      </Link>
    </div>

    </Container>

    <Footer/>
    </>
  );
};

export default Signin;
