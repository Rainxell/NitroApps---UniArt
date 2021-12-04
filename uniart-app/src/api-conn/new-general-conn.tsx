import React from 'react';
import { Formato } from '../models/formato';
import { Estilo } from '../models/estilo';
import { Tecnica } from '../models/tecnica';
import { Tema } from '../models/tema';
import { Licencia } from '../models/licencia';
import NewSGeneral from '../pages/service/new-general';

//reemplazar con datos de la BD
let formatos:Formato[] = [
  {id: 0, nombre: "PNG"},
  {id: 1, nombre: "JPG"},
  {id: 2, nombre: "GIFF"},
  {id: 3, nombre: "TIFF"},
  {id: 4, nombre: "BMP"},
  {id: 5, nombre: "SVG"},
  {id: 6, nombre: "EPS"},
  {id: 7, nombre: "Illustrator"},
  {id: 8, nombre: "Photoshop"},
];
let estilos:Estilo[] = [
  {id: 1, nombre: "anime"},
  {id: 2, nombre: "cartoon"},
  {id: 3, nombre: "cuentos infantiles"},
  {id: 4, nombre: "vector"},
  {id: 5, nombre: "oscuro"},
  {id: 6, nombre: "boceto"},
  {id: 7, nombre: "lineart"},
  {id: 8, nombre: "colores planos"},
  {id: 9, nombre: "full color"},
];
let tecnicas:Tecnica[] = [
  {id: 0, nombre: "tecnica mixta"},
  {id: 1, nombre: "acuarelas"},
  {id: 2, nombre: "digital"},
  {id: 3, nombre: "acrílico"},
];
let temas:Tema[] = [
  {id: 0, nombre: "personajes"},
  {id: 1, nombre: "animales"},
  {id: 2, nombre: "furros"},
  {id: 3, nombre: "paisajes"},
  {id: 4, nombre: "interiores"},
  {id: 5, nombre: "videojuegos"},
  {id: 6, nombre: "diseño"},
  {id: 7, nombre: "logo"},
  {id: 8, nombre: "avatar"},
  {id: 9, nombre: "sticker"},
  {id: 10, nombre: "UI"},
];

let licencias:Licencia[] = [
  {id: 0, nombre: "uso personal"},
  {id: 1, nombre: "creative commons"},
  {id: 2, nombre: "uso comercial con comisión"},
  {id: 3, nombre: "uso comercial"},
];

function NewSGeneralConn(props:{id?:string}) {
  return (
    <NewSGeneral id = {props.id}
      formatos = {formatos}
      estilos = {estilos}
      tecnicas = {tecnicas}
      temas = {temas}
      licencias = {licencias}
    />
  );
};

export default NewSGeneralConn;
