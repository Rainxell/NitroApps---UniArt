import React from 'react';
import { Container, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, TextField, Typography } from '@mui/material';
import Footer from '../../components/dashboard/footer';
import { Pais } from '../../models/pais';
import { Ciudad } from '../../models/ciudad';
import { ListPaises } from '../../api/apiPais';
import { ListCiudades } from '../../api/apiCiudad';

function CountryCity(props:{city:number, setCity:(id:number)=>void}) {
  const {paises, refreshPaises} = ListPaises();
  const {ciudades, refreshCiudades} = ListCiudades(); 
  const [pais, setPais] = React.useState(0);
  //{pais:{id:89,nombre:'Perú'}, ciudad:{id:1610,nombre:'Lima',pais_id::89}}

  const citiesInCountry = (idCountry:number)=>{
    let _citiesInC: Ciudad[] = [];
    ciudades.forEach((c)=>{
      if (c.pais_id === idCountry) { _citiesInC.push(c); }
    });
    return _citiesInC;
  };

  const [citiesInC, setCities] = React.useState( [new Pais()] );
  React.useEffect(() => {
    refreshPaises();
    refreshCiudades();
    setPais(89);
    setCities(citiesInCountry(89));
    props.setCity(1610);
  }, [ciudades.length===0]);

  const handleCountryChange = (event: SelectChangeEvent) => {
    setPais(+event.target.value);
    setCities(citiesInCountry(+event.target.value));
  };
  const handleCityChange = (event: SelectChangeEvent) => {
    props.setCity(+event.target.value);
  };


  return ( <>
    <FormControl required>
      <InputLabel id="countries-label">País</InputLabel>
      <Select labelId="countries-label" id="countries"
      value={pais+''}
      onChange={handleCountryChange} label="Países" >
        {paises.map((p)=>{return(
          <MenuItem value={p.id}>{p.nombre}</MenuItem>
        )})}
      </Select>
    </FormControl>

    <FormControl required>
      <InputLabel id="ciudad-label">Ciudad</InputLabel>
      <Select labelId="ciudad-label" id="ciudades"
      value={props.city+''}
      onChange={handleCityChange} label="Ciudades"> 
        {citiesInC.map((c)=>{return(
          <MenuItem value={c.id}>{c.nombre}</MenuItem>
        )})}
      </Select>
    </FormControl>
  </> )
};

export default CountryCity;
