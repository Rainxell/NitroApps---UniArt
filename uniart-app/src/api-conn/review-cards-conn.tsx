import React from 'react';
import {dateDiff} from '../utils/dateFx';
import { ReviewCardProps } from '../components/card-custom/review-card';
import { Review } from '../models/review';
import { Usuario } from '../models/usuario';
import { Pais } from '../models/pais';
import { Comision } from '../models/comision';
import { Valoracion } from '../models/valoracion';
import ReviewCards from '../components/card-custom/review-cards';

//const since = datediff(review.fecha);

/*
const questions = [
    
  ];

  
  
 */


function ReviewCardsConn(props:{id_artista?:number,id_servicio?:number}) {
  let url_img_base = `${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg`;

  //EN REVIEW EN LA BD FALTA ID SERVICIO ID USUARIO
  
  //BORRAR
  let auxR: Review = {
    id: 1,
    //id_servicio: 1,
    //id_usuario: 1,
    rating_cliente: 2,
    comentario: ["Lorem ipsum dolor sit amet, consectetur adipiscing elit,",
    "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
    "Ut enim ad minim veniam, quis nisi ut aliquip ex ea commodo consequat.",
    "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum ",
    "dolore eu fugiat nulla pariatur."].join(''),
    fecha: new Date(),
    valor_Positivo: 10,
    valor_Negativo: 1,
    //url_img_referencia: `${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg`,
  };

  
  //reemplazar por el get en la BD
  let reviews = [auxR,auxR,auxR,auxR,auxR,auxR,auxR,auxR,auxR,auxR,auxR,auxR];
  /* CONECTAR CON LA BD Y OBTENER LOS SERVICIOS
  //SI SE ENVIA UN ID, SOLO los servicios de ese ARTISTA ID
  //SINO de todo
  id: number = 0;
  nombre_usuario: string = "Artista";
  password: string = "";
  email: string = "";
  nombre: string = "";
  apellido: string = "";
  ciudad_id: number = 0;
  url_foto_perfil: string = "";
  fecha_registro: Date = new Date();
  descripcion: string = "";
  url_foto_portada: string = `${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg`;
  rating: number = 0;
  q_valoraciones: number = 0;
  */

  const getUser = (id:number)=>{
    const usuario = new Usuario(); //reemplazar por el get en la BD
    return usuario;
  };
  const getCountryByCityId = (id:number)=>{
    const pais = new Pais(); //reemplazar por el get en la BD
    return pais.nombre;
  };
  const getServiceDetails = (id:number)=>{ //id del servicio
    //[]
    return [
      {question: '1', answer: "Respuesta 1"},
      {question: '2', answer: "Respuesta 2"},
      {question: '3', answer: "Respuesta 3"},
    ]
  };

  const getValorUsuario = (id_usuario:number, id_review:number) => {
    let su = new Valoracion(); //reemplazar por el get en la BD
    // si no existe, retornar 0
    return su.es_like? 1 : -1;
  }

  const getUrlImagenBase = (id:number) => { //id del servicio
     //reemplazar por el get en la BD
    //obtener solo el 1ero de la base de datos
    //let c = new Comision();
    //debería revisar la imagen entregada y si no existe, la imagen default del servicio
    return url_img_base;
  };

  //pasandolo a un formato para las cards
  const servCards = () => {
    let rs:ReviewCardProps[] = new Array<ReviewCardProps>(0);
    reviews.map((r,i)=>{
      //let u = getUser(r.id_usuario);
      rs.push({
        id: r.id,
        user_url_img: "u.url_foto_perfil",
        user_name: "u.nombre_usuario",
        user_rating: 5, //el usuario no tiene rating, debería
        user_qreviews: 10,  //el usuario no tiene cantidad de reviews, debería
        service_time_diff: dateDiff(r.fecha),
        user_country: "", // getCountryByCityId(u.ciudad_id),
        service_details: getServiceDetails(r.id),
        review: r.comentario,
        valor_usuario: 0, //getValorUsuario(u.id,r.id),
        valor_positivo: r.valor_Positivo,
        valor_negativo: r.valor_Negativo,
        url_img: getUrlImagenBase(r.id),
      });
    });
    return rs;
  };

  return  <ReviewCards list={servCards()}/> ;

};

export default ReviewCardsConn;
