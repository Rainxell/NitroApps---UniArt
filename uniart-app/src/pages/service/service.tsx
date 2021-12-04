import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import { Button, Grid, Typography,
  Stepper, Step, StepLabel, Container, StepContent, Divider, Link, TextField, FormControlLabel, FormControl, Checkbox, Stack, Autocomplete, InputAdornment, FormHelperText, Input, InputLabel, Select, MenuItem, SelectChangeEvent, Avatar, ListItem, ListItemIcon, ListItemText, Rating, Paper } from '@mui/material';
import { Servicio } from '../../models/servicio';
import { Artista } from '../../models/artista';
import { Review } from '../../models/review';
import { GetServicio } from '../../api/apiServicio';
import ReviewCard, { ReviewCardProps } from '../../components/card-custom/review-card';
import { ListComision } from '../../api/apiComision';
import { GetReview, ListReview } from '../../api/apiReview';
import { Usuario } from '../../models/usuario';
import { ListUsuarios } from '../../api/apiUsuario';
import {dateDiff} from '../../utils/dateFx';
import apiArtista, { GetArtista } from '../../api/apiArtista';
import { blacks, themeMui } from '../../themes/theme-mui';
import Footer from '../../components/dashboard/footer';

interface ServiceProps {
  service: Servicio;
  artista: Artista;
  reviews: ReviewCardProps[];
}

function Service() {
  const {service} = useParams(); //id del servicio 
  const [serv, setServ] = useState<ServiceProps>({
    service:new Servicio(), artista: new Artista(), reviews: []
  });
  const {comisiones, refreshComisiones} = ListComision();
  const {reviews, refreshReviews} = ListReview();
  const { users, refreshUsuarios } = ListUsuarios();
  //const [reviewCards, setReviewCards] = useState<ReviewCardProps>();
  const {servicio, refreshServicio} = GetServicio(service? +service:0);
  const {artista, refreshArtista} = GetArtista(servicio.artista_id+0);
  

  const getUserById = (idUser:number) => {
    for (let i = 0; i < users.length; i++) {
      if ( users[i].id === idUser ){ return users[i] }
    }
    return new Usuario();
  };

  const getReviewById = (idReview:number) => {
    for (let i = 0; i < reviews.length; i++) {
      if (idReview === reviews[i].id) {
        return reviews[i];
      }
    }
    return new Review();
  };

  const getReviews = () => {
    let rcs = new Array<ReviewCardProps>();
    //x = x.filter((o, i) => o.props.index != elDel); //index
    const comisionesServ = comisiones.filter((c)=> c.servicio_id === serv.service.id );

    comisionesServ.forEach((c,i)=>{
      //solo review del cliente
      //const {review, refreshReview} = GetReview(c.review_id_clienteid);
      const rev = getReviewById(c.review_id_clienteid);
      const usu = getUserById(c.usuario_id);

      rcs.push({
        id: rev.id,
        user_url_img: usu.url_foto_perfil,
        user_name: usu.nombre_usuario,
        //user_rating: usu.
        // user_qreviews?: number,
        service_time_diff: dateDiff(rev.fecha),
        //user_country?: string,
        // service_details?: {question:string, answer:string}[],
        review: rev.comentario,
        valor_usuario: 0,
        valor_positivo: rev.valor_Positivo,
        valor_negativo: rev.valor_Negativo,
        // url_img?: string
      });
    });

    return rcs;
  };

  // React.useEffect(()=>{
  //   apiServicio.detail(id).then((res)=>{
  //     console.log('i servicio:',res);
  //     setServicio(res);
  //   }).catch(()=>{"no listó Servicio"});
  // },[]);
  
  useEffect(()=>{
    refreshServicio();
    refreshArtista();
  },[]);

  useEffect(()=>{ 
    console.log("artista...en serv",artista);
  },[artista]);

  
  useEffect(()=>{
    console.log('aid: ', serv.service, serv.service.artista_id);
    
    const loadA = async () => {
      await apiArtista.detail(serv.service.artista_id).then((res)=>{
        //setArtista(res);
        setServ({...serv, artista: res })
        console.log('i artista de serv:',res);
      }).catch( ()=>{"no listó artista"} );
    }

    loadA();
  },[serv.service.artista_id]); // === undefined
  
  useEffect(()=>{
    //refreshServicio();
    console.log('servs: ', (servicio as Servicio), (servicio as Servicio).artista_id); 
    setServ({...serv, service:(servicio as Servicio) }); 
  },[servicio]); // !== undefined 
  
  // useEffect(()=>{
  //   setServ({...serv, artista:artista })
  // },[artista]); 
  
  useEffect(() => {
    //refreshServicio();
    refreshUsuarios();
    //refreshComisiones();
    refreshReviews();
    setServ({...serv, reviews:getReviews() })
    // setServ({...serv, service:servicio });
  }, [reviews.length===0])


  return (
    <Container>
    <Grid container spacing={2}> 
      <Grid item xs={6}>
        <Paper  sx={{backgroundColor: blacks.dark, backgroundImage: `url(${serv.service.url_imagen})`,
        backgroundPosition: "center", backgroundSize: "cover",
        width:'100%', height:'20rem' }} />
        <br/><br/>
        {serv.reviews.map((r)=>{
          return (<ReviewCard {...r} />)
        })}

      </Grid>

      <Grid item xs={6}>
        <Grid container>
          <Grid item xs={6}>
            <ListItem>
              <ListItemIcon>
                <Avatar sx={{ bgcolor: themeMui.palette.primary.main,
                  width: 24, height: 24 }} alt={serv.artista.nombre_usuario}
                  src={serv.artista.url_foto_perfil}  />
              </ListItemIcon>
              <ListItemText>
                {serv.artista.nombre_usuario}
              </ListItemText>
            </ListItem>
          </Grid>
          <Grid item xs={6}>
            <ListItem>
              <ListItemIcon> 
                <Rating value={serv.artista.rating===undefined?3:serv.artista.rating} readOnly/>
              </ListItemIcon>
              <ListItemText>
                  {serv.artista.rating} ({serv.artista.q_valoraciones})
              </ListItemText>
            </ListItem>
          </Grid>
        </Grid>
        <br/>
        <Typography variant="h3"> {serv.service.nombre} </Typography>
        <br/>
        <Grid container>
          <Grid item xs={6}>{serv.service.precio_base}</Grid>
          <Grid item xs={6}>{serv.service.es_virtual? "Envío digital" : ""}</Grid>
        </Grid>
        <br/>
        <Button>Editar servicio</Button>
        <Button variant="contained">¡Realizar compra!</Button>
        <br/>
        <ListItem>
          <ListItemIcon>
            Licencia
          </ListItemIcon>
          <ListItemText>
            {serv.service.licencia_id}
          </ListItemText>
        </ListItem>
        <ListItem>
          <ListItemIcon>
            Cantidad de revisiones sin costo adicional
          </ListItemIcon>
          <ListItemText>
            {serv.service.q_revisiones}
          </ListItemText>
        </ListItem>
        <ListItem>
          <ListItemIcon>
            % de delanto
          </ListItemIcon>
          <ListItemText>
            {serv.service.porc_adelanto}
          </ListItemText>
        </ListItem>
        <ListItem>
          <ListItemIcon>
            Cantidad de días base
          </ListItemIcon>
          <ListItemText>
            {serv.service.duracion_esperada} días
          </ListItemText>
        </ListItem>
        <ListItem>
          <ListItemIcon>
            Reembolsable
          </ListItemIcon>
          <ListItemText>
            {serv.service.acepta_rembolso? "SÍ":"No"}
          </ListItemText>
        </ListItem>
        <ListItem>
          <ListItemIcon>
            Estilo
          </ListItemIcon>
          <ListItemText>
            {serv.service.estilo_id}
          </ListItemText>
        </ListItem>
        <ListItem>
          <ListItemIcon>
            Técnica
          </ListItemIcon>
          <ListItemText>
            {serv.service.tecnica_id}
          </ListItemText>
        </ListItem>


        <div>
          <Typography variant="h5">Acerca del servicio</Typography>
          <p>{serv.service.acerca_servicio}</p>
        </div>
      </Grid>
    </Grid>


    <Footer/>
    </Container>
  );
};

export default Service;
export {};