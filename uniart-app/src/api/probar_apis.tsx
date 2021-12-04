import React from "react"; 
import { Artista } from "../models/artista";
import { CreateArtista, DeleteArtista, GetArtista, ListArtistas, UpdateArtista } from "./apiArtista";



function CRUDprueba(props:any){

  const a = {
    id: 0,
    nombre_usuario: "DEBERIA SER AUTOINCREMENT",
    password: "12564565 qaaqa",
    email: "artis@ggg.com",
    nombre: "PRUEBA WHYYY",
    apellido: "Artista",
    ciudad_id: 5,
    url_foto_perfil: "https://indiehoy.com/wp-content/uploads/2019/01/loki.jpg",
    fecha_registro: new Date(),
    descripcion: "a mklasmdlakmda asd asdqw",
    url_foto_portada: `https://png.pngtree.com/element_our/20200702/ourlarge/pngtree-25d-people-waiting-for-the-bus-image_2296896.jpg`,
    rating: 4,
    q_valoraciones: 188,
  };

  const {artistas, refreshArtistas} = ListArtistas();
  const {artista, refreshArtista} = GetArtista(a.id-1);
  const [vals, setVals] =
    React.useState<{i?:Artista,ls:Artista[]}>({ls:[]});

  const validate = ()=>{
    refreshArtistas();
    setVals({ls:artistas});
    console.log('validando:',vals);
  };

  React.useEffect(()=>{
    refreshArtista();
    setVals({i:artista,ls:artistas});
    CreateArtista(a);
    validate();
    UpdateArtista(a);
    validate();
    DeleteArtista(a.id);
    validate();
  },[artistas.length===0,artista===null,artista===undefined]);


  return (<div><p>
    ID: {vals.i?.id} | nombre: {vals.i?.nombre}
    </p>
    <div>
    {vals.ls.map((x,i)=>{return <p>{i} {x.id} {x.nombre}</p>})}
  </div></div>); 
};

export default CRUDprueba;
export {};

