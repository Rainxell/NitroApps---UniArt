import React, { ReactEventHandler } from 'react';
import { useNavigate } from 'react-router';
import { useUser } from './userContext';
import Footer from '../../components/dashboard/footer';
import { Button, Container, FormControl, InputLabel, Link, MenuItem, Select, SelectChangeEvent, TextField, Typography } from '@mui/material';


const Login = () => {
  const {user, login} = useUser();
  const navi = useNavigate();
  const [username, setUsername] =  React.useState("");
  const [password, setPassword] =  React.useState("");
  //const [userlog, setUserLog] = React.useState({username:"", password:""})

  if (user !== undefined && user.nombre_usuario!=""){ // || 
    console.log(user);
    navi('/explore', { replace: true });
    return <></>
  }

  const handleLogin = () => {
    if (username !== "" && password !== ""){
      //validar usuario
      login(username,password);
      //Si se pudo loguear
      navi('/explore', { replace: true });
    }
  };

  return (
    <>
    <Container maxWidth={"xs"} sx={{
      display:"flex", flexDirection:"column",
      rowGap:"1em", 
    }}>
    
    <img src={`${process.env.PUBLIC_URL}/images/logo_full.svg`}/>
    <br/>
    <TextField id="username" label="Nombre de usuario" required
    value={username} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(event.target.value);
      }
    }/>
    <TextField id="passwords" label="Contraseña" required type="password"
    value={password} onChange={
      (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
      }
    }/>

    <br/>
    <Button variant="contained" onClick={handleLogin}> 
      Iniciar Sesión
    </Button>
    <br/><br/>

    <div>
      ¿Aún no tienes cuenta?
      <br/><br/>
      <Link href="/signin">
        <Button>Crear cuenta</Button>
      </Link>
    </div>

    </Container>

    <Footer/>
    </>
  );
};

export default Login;
