import React, { ReactEventHandler, useState } from 'react';
import { useNavigate } from 'react-router';
import { useUser } from '../session/userContext';
import Footer from '../../components/dashboard/footer';
import { Button, ButtonBase, Container, FormControl, Grid, InputLabel, Link, MenuItem, Select, SelectChangeEvent, TextField, Typography } from '@mui/material';
import { blacks, themeMui, whites } from '../../themes/theme-mui';
import { Box, styled } from '@mui/system';
import { Usuario } from '../../models/usuario';
import { Artista } from '../../models/artista';
import CountryCity from '../../components/form/country-city';
import { UpdateArtista } from '../../api/apiArtista';
import { UpdateUsuario } from '../../api/apiUsuario';
//import { CreateUsuario } from "../../api/apiUsuario";

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

function Settings(props:any) {
  const {user, signup} = useUser();
  const navi = useNavigate();
  const [ curUser, setCurUser ] = useState(user);
  const [city, setCity] = useState(0);
  // React.useEffect(()=>{
  // },[]);

  React.useEffect(()=>{
    console.log(city);
    setCurUser({...curUser,ciudad_id:city});
  },[city]);
  
  
  if (user === undefined || user.nombre_usuario===""){ // || 
    console.log("no está logueado");
    navi('/login', { replace: true });
    return <></>
  }

  const isArtist = (user as Artista).descripcion !== undefined; 
  
  const handleSave = () => {
    console.log('cambiando a...',curUser);
    if (curUser.nombre_usuario === "" ||
        curUser.password === "" ||
        curUser.email === "" ||
        curUser.nombre === "" ||
        curUser.apellido === "" //||
        //curUser.ciudad_id === 0
    ) {
      alert("datos incompletos");
      return;
    }
    if ( curUser.url_foto_perfil === "" ) {
      const randpos = Math.random() * (avatarsPred.length -1);
      curUser.url_foto_perfil = avatarsPred[randpos];
    }
    if (isArtist && (curUser as Artista).descripcion === "" ){
      alert("Completar descripción");
      return; 
    }
    
    if (isArtist){
      UpdateArtista(curUser as Artista);
    } else {
      UpdateUsuario(curUser as Usuario);
    }
    alert('¡Guardado!');
  };
  
  const artistDataJsx = ()=>{
    return (<>
    <TextField id="descripcion" label="Descripción" required type="email"
    value={(curUser as Artista).descripcion} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurUser({...curUser, descripcion:event.target.value });
      }
    }/>
    <TextField id="foto_portada" label="URL de foto de portada"
    value={(curUser as Artista).url_foto_portada} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurUser({...curUser, url_foto_portada:event.target.value });
      }
    }/>
    </>);
  }

  return (
    <>
    <Container maxWidth={"xs"} sx={{
      display:"flex", flexDirection:"column",
      rowGap:"1em", 
    }}>
     
    <Typography variant="h4">Configuración</Typography>

    <TextField id="username" label="Nombre de usuario" required
    value={curUser.nombre_usuario} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurUser({...curUser, nombre_usuario:event.target.value });
      }
    }/>
    <TextField id="password" label="Contraseña" required type="password"
    value={curUser.password} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurUser({...curUser, password:event.target.value });
      }
    }/>
    <TextField id="email" label="Correo electrónico" required type="email"
    value={curUser.email} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurUser({...curUser, email:event.target.value });
      }
    }/>
    <TextField id="nombre" label="Nombres" required
    value={curUser.nombre} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurUser({...curUser, nombre:event.target.value });
      }
    }/>
    <TextField id="apellidos" label="Apellidos" required
    value={curUser.apellido} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurUser({...curUser, apellido:event.target.value });
      }
    }/>
    <TextField id="foto_perfil" label="URL de foto de perfil"
    value={curUser.url_foto_perfil} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurUser({...curUser, url_foto_perfil:event.target.value });
      }
    }/>
    
    <CountryCity city={city} setCity={setCity} />

    {isArtist ? artistDataJsx() : <></>}
    
    <br/>
    <Button variant="contained" onClick={handleSave}>
      Guardar cambios
    </Button>
    <br/><br/>

    </Container>

    <Footer/>
    </>
  );
};

export default Settings;
export {};