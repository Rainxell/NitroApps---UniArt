import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import { GetArtista } from '../../api/apiArtista';
import { GetServicio } from '../../api/apiServicio';
import { Servicio } from '../../models/servicio';

function Service2() {
  const {service} = useParams();
  const [servi, setServi] = useState<Servicio>();
  const {servicio, refreshServicio} = GetServicio(service? +service:0);
  const {artista, refreshArtista} = GetArtista(31);
  
  useEffect(() => {
    refreshServicio();
    refreshArtista();
  }, []);
  useEffect(()=>{
    refreshArtista(); 
    //refreshServicio();
    let aux = JSON.stringify(servicio);
    console.log(aux,'-a-',JSON.parse(aux)["artista_id"]); 
    setServi(servicio);
  },[servicio !== undefined]); 

  return (
    <div>
      {servicio.nombre}
      {artista.nombre}
      {servi?.id} 
      {servi?.nombre} 
    </div>
  );
};

export default Service2;
export {};