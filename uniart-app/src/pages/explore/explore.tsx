import React, { useState } from 'react';
import { Container, Typography } from '@mui/material';
import Footer from '../../components/dashboard/footer';
import { themeMui } from '../../themes/theme-mui';
import Filter from './filter';
import Fab from '@mui/material/Fab';
import NavigateNextIcon from '@mui/icons-material/NavigateNext';
import ArtistCards from '../../components/card-custom/artist-cards';
import ServiceCards from '../../components/card-custom/service-cards';
import { ListTema } from '../../api/apiTema';
import { ListEstilo } from '../../api/apiEstilo';
import { ListTecnica } from '../../api/apiTecnica';
import { ListPaises } from '../../api/apiPais';


function Explore() { 
  const [search, setSearch] = useState('');
  const {temas, refreshTemas} = ListTema();
  const {estilo, refreshEstilo} = ListEstilo();
  const {tecnica, refreshTecnica} = ListTecnica();
  const {paises, refreshPaises} = ListPaises();
  

  const defaultCheck = {value: 0, label:"", checked: true};
  const defaultFilters = {
    orderBy: {
      options: [
        {value:0, label:"Más recientes"},
        {value:1, label:"Más antiguos"},
        {value:2, label:"Más económicos"},
      ],
      selected: 0
    },
    themes: [ defaultCheck ],
    styles:  [ defaultCheck ],
    techniques: [ defaultCheck ],
    countries: [ defaultCheck ],
    ratingR: { min:0, max:5 },
    priceR: { min:1, max:10000 },
    duration: { min:0, max:60 }
  }
  const [filters, setFilters] = useState(defaultFilters);

  React.useEffect(() => {
    const params = new URLSearchParams(window.location.search);
    const q = params.get("q");
    setSearch(q?q: "");
  }, [])

  const toCheckBox = (vals:{id:number,nombre:string}[])=>{
    let aux = new Array<{value:number, label:string, checked:boolean}>();
    vals.forEach((v)=>{
      aux.push({value:v.id, label:v.nombre, checked:true});
    });
    return aux;
  }
  React.useEffect(()=>{
    refreshTemas();
    filters.themes = toCheckBox(temas);
    setFilters(filters);
  },[temas.length===0,temas===null,temas===undefined]);
  React.useEffect(()=>{
    refreshEstilo();
    filters.styles = toCheckBox(estilo);
    setFilters(filters);
  },[estilo.length===0,estilo===null,estilo===undefined]);
  React.useEffect(()=>{
    refreshTecnica();
    filters.techniques = toCheckBox(tecnica);
    setFilters(filters);
  },[tecnica.length===0,tecnica===null,tecnica===undefined]);
  React.useEffect(()=>{
    refreshPaises();
    filters.countries = toCheckBox(paises);
    setFilters(filters);
  },[paises.length===0,paises===null,paises===undefined]);

  return (<>
  <Filter filters={filters} setFilters={setFilters}/>

  <Container className={"after-drawer"} sx={{
    backgroundColor:themeMui.palette.primary.main,
    backgroundImage: `url("${process.env.PUBLIC_URL}/images/bgs/coffetti.svg")`,
    backgroundAttachment: "fixed",
    color:themeMui.palette.primary.contrastText}}
  > 
    <Typography variant="h2" >¡Artistas en estreno!</Typography>
    <br/>
    {<ArtistCards max={5}/>}
    <br/>
    <Fab color="primary" aria-label="add"
    sx={{position: "absolute", marginTop: "-10rem", right: "1rem",}}>
      <NavigateNextIcon />
    </Fab>
  </Container>

  <Container  className={"after-drawer"}>
    <ServiceCards max={20} search={search} filters={filters}/>
  </Container>

  <Footer className={"after-drawer"}/>
  </>);
};
//<InboxIcon /><MailIcon />
export default Explore;
