import { Duracion } from "./duracion";

export class Servicio {
  id: number = 0;
  nombre: string = "";
  artista_id: number = 0;
  duracion_esperada: any = undefined; // {days:0}//new Duracion();
  precio_base: number = 0;
  rating: number = 0;
  q_valoraciones: number = 0;
  es_virtual: boolean = true;
  porc_adelanto: number = 0;
  acepta_rembolso: boolean = false;
  estilo_id: number = 0;
  tecnica_id: number = 0;
  acerca_servicio: string = "";
  licencia_id: number = 0;
  q_revisiones: number = 0; //q_reviciones
  url_imagen: string = "";
};