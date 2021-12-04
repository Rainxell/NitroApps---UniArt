import React from 'react';
import { Divider, Grid, Typography } from '@mui/material';
import ServiceCard from '../../components/card-custom/service-card';
import { Artista } from '../../models/artista';

interface ServGralProps{
  name: string, //nombre servicio
  since_time: number,
  since_price: number
}

function NewVariation(props:ServGralProps) {
  //USAR EL ARTISTA LOGEADO
  let artist = new Artista();
  artist.nombre_usuario = "Artistaaa";
  
  const [cardPrev, serCardPrev] = React.useState({id: 0,
    url_img: `${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg`,
    name: props.name,
    artist_url_img: artist.url_foto_perfil,
    artist_name: artist.nombre_usuario,
    artist_rating: artist.rating,
    artist_qreviews: artist.q_valoraciones,
    since_time: props.since_time,
    since_price: props.since_price,
  });


  return (<>

  <Typography variant="h3">Variaciones del producto según características</Typography>
  <br/><br/>
  <Grid container spacing={2}>
    <Grid item xs={5}>
      <Typography component="p">
      Considerar que la primera variación debe contener la versión que
      más espera que soliciten los usuarios y tiene la imagen que se
      usará para promocionar su producto.
      </Typography>
    </Grid>
    <Grid item xs={5}>
      <Typography component="p">
      Solo se permiten un máximo de 10 variaciones.
      Las cabeceras en amarillo no podrán ser elegidas por el usuario.
      </Typography>
    </Grid>
    
  </Grid>

  <br/><br/><Divider/><br/><br/>
  
  <Grid container >
    <ServiceCard {...cardPrev} />
  </Grid>

  
  </>)
}

export default NewVariation;
