import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";
import AppBar from '@mui/material/AppBar';
import Autocomplete from '@mui/material/Autocomplete';
import TextField from '@mui/material/TextField';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
//import Link from '@mui/material/Link';
import { IconButton, Menu, MenuItem, Avatar, Link, Toolbar } from '@mui/material';
import AccountCircle from '@mui/icons-material/AccountCircle';
import SearchIcon from '@mui/icons-material/Search';
import ExploreTTIcon from '@mui/icons-material/ExploreTwoTone';
import ChatBubbleTTIcon from '@mui/icons-material/ChatBubbleTwoTone';
import AssessmentTTIcon from '@mui/icons-material/AssessmentTwoTone';
import ShoppingCartTTIcon from '@mui/icons-material/ShoppingCartTwoTone';
import Settings from '@mui/icons-material/Settings';
import Logout from '@mui/icons-material/Logout';
import PersonAdd from '@mui/icons-material/PersonAdd';
import Login from '@mui/icons-material/Login';
import { useUser } from '../../pages/session/userContext';

interface LinkTabProps {
  value?: number;
  label?: string;
  href: string; 
  icon?: string | React.ReactElement<any,string> | undefined;
};

const Header = () => {
  const {user, logout} = useUser();
  const navi = useNavigate();
  const defaultName = "Desconocido";
  const nomusu = user === undefined || user === null?
  defaultName : user.nombre_usuario === ""? defaultName : user.nombre_usuario ;
  
  const tabItems: Array<LinkTabProps> = [
    { label:"Explorar", href:"/explore", icon:<ExploreTTIcon /> },
    { label:"Chat", href:"/chat", icon:<ChatBubbleTTIcon /> },
    { label:"Comisiones", href:"/commissions", icon:<AssessmentTTIcon /> },
    { label:"Compras", href:"/cart", icon:<ShoppingCartTTIcon /> },
  ];
  const userMenuItems: Array<LinkTabProps> = 
  nomusu === defaultName ? [ 
    { label:"Crear cuenta", href:"/signin", icon:<PersonAdd fontSize="small" /> },
    { label:"Iniciar sesion", href:"/login", icon:<Login fontSize="small" />  },
  ] : [ //deberia recoger el username
    { label:"Perfil", href: user === undefined? "/login": `/${user.nombre_usuario}`, icon:<AccountCircle fontSize="small" /> },
    { label:"Configuración", href:"/settings", icon:<Settings fontSize="small" />  },
    //{ label:"Cerrar Sesión", href:"/logout", icon:<Logout fontSize="small" />  }
  ];
  //CAMBIAR POR NOMUSU

  const sugerencias = [ //Temas, estilos, técnicas
    "personajes", "anime", "videojuegos", "avatar", "stickers",
    "comic", "diseño UI", "logo", "logotipo", "seirrealismo"
  ]


  const checkTab = () => { //__dirname
    if (window.location.pathname === nomusu) {return tabItems.length+1;}
    for (let i = 0; i < tabItems.length; i++) {
      if (tabItems[i].href === window.location.pathname) {return i;}
    }
    for (let i = 0; i < userMenuItems.length; i++) {
      if (userMenuItems[i].href === window.location.pathname) {
        return tabItems.length+1;
      }
    }
    return 0;
  };
  
  const [tabIdx, setTabIdx] = useState(checkTab);
  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setTabIdx(newValue);
  };

  const [search, setSearch] = useState("");
  
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);  
  const isMenuOpen = Boolean(anchorEl);
  
  const handleProfileMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  }; 
  const handleMenuClose = (href:string) => () => {
    if (href != '') {
      navi(href,{replace:true});
    }
    setAnchorEl(null);
    //handleMobileMenuClose();
  }; 
  const menuId = 'primary-search-account-menu';
  const menuPaperProps = {
    elevation: 0,
    sx: {
      overflow: 'visible',
      filter: 'drop-shadow(0px 2px 8px rgba(0,0,0,0.32))',
      mt: 1.5,
      '& .MuiAvatar-root': {
        width: 32,
        height: 32,
        ml: -0.5,
        mr: 1,
      },
      '&:before': {
        content: '""',
        display: 'block',
        position: 'absolute',
        top: 0,
        right: 14,
        width: 10,
        height: 10,
        bgcolor: 'background.paper',
        transform: 'translateY(-50%) rotate(45deg)',
        zIndex: 0,
      },
    },
  };

  /* <Toolbar variant="dense" sx={{padding:"0px",}}> */

  return (
    <AppBar position="fixed">
      <Toolbar>
      <Link href="/"><img src={process.env.PUBLIC_URL + '/images/logo.svg'}
            style={{height:'2rem',}} alt="logo"/></Link>
      <Autocomplete freeSolo id="search" style={{ flexGrow: 1, }}
          value = {search} options={sugerencias}
          onChange = { (e: React.SyntheticEvent<Element, Event>, value:string|null)=>{
            console.log(value);
            if(value!=null) { setSearch(value);}
          } }
          renderInput={(params) =>
            <TextField {...params} label="Nombre del servicio o artista" variant="standard" />}  
          />
      <IconButton type="submit" aria-label="search"
      sx={{ height: 'fit-content', }}
      onClick={
        ()=>{ navi(`/explore?q=${search}`,{replace:true}); }
      }>
        <SearchIcon />
      </IconButton>

        <Tabs value={tabIdx} onChange={handleChange} scrollButtons={false}
          sx={{
            '& .MuiTabs-flexContainer': {
              alignItems: "center", width:'100%',
              columnGap: "0.5rem", rowGap: "0.5rem", 
            }
          }}>

          {tabItems.map((t,i)=>{
            return (
              <Tab component="a" value={i}
              label={t.label?t.label:''} href={t.href}
              icon={t.icon?t.icon:''}
              onClick={(event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
                event.preventDefault();
                navi(t.href, { replace: true });
              }} />
            );
          })}

          <Tab label={nomusu} onClick={handleProfileMenuOpen}
          icon={
            <Avatar alt={nomusu} src={user?.url_foto_perfil}
            sx={{ width: '1.5rem', height: '1.5rem'}}
          />}
          aria-controls={menuId} aria-haspopup="true" value={5} />
          <Menu id={menuId} anchorEl={anchorEl} keepMounted PaperProps={menuPaperProps}
          anchorOrigin={{ vertical: 'top', horizontal: 'right', }}
          transformOrigin={{ vertical: 'top', horizontal: 'right', }}
          open={isMenuOpen} onClose={handleMenuClose('')} >
          {userMenuItems.map( (umi,i)=>{return(
              <MenuItem onClick={handleMenuClose(umi.href)}>
                {umi.icon} {umi.label}
              </MenuItem>
          )} )}
          {
            nomusu !== defaultName ?
              <MenuItem onClick={()=>{
                logout();
                navi('/explore', { replace: true });
              }}> 
                <Logout fontSize="small" /> Cerrar Sesión
              </MenuItem>
              : <></>
          }

          </Menu>

        </Tabs>
        </Toolbar>
    </AppBar>
  );
};


export default Header;
export {};