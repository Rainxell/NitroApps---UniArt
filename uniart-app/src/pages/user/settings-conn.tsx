import React from 'react';
import Settings from './settings';

//CONECAR CON LA BD
const countries = [
  {id: 1, nombre: "Perú"},
  {id: 2, nombre: "Angentina"},
  {id: 3, nombre: "Brasil"},
  {id: 4, nombre: "Bolivia"},
  {id: 5, nombre: "Colombia"},
];
const cities = [
  {pais_id: 1, id: 1, nombre: "Lima"},
  {pais_id: 1, id: 2, nombre: "Arequipa"},
  {pais_id: 1, id: 3, nombre: "Trujillo"},
  {pais_id: 2, id: 4, nombre: "Bogotá"},
  {pais_id: 2, id: 5, nombre: "Ciudad"},
];

function SettingsConn() {
  return (
    <Settings countries={countries} cities={cities}/>
  );
};

export default SettingsConn;
