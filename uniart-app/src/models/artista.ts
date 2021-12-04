export class Artista {
  id: number = 0;
  nombre_usuario: string = "";
  password: string = "";
  email: string = "";
  nombre: string = "";
  apellido: string = "";
  ciudad_id: number = 0;
  url_foto_perfil: string = "";
  fecha_registro: Date = new Date();
  descripcion: string = "";
  url_foto_portada: string = ""; //${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg
  rating: number = 0;
  q_valoraciones: number = 0;
  //delete: boolean = false;
};