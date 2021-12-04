import React from 'react';
import { themeMui } from '../../themes/theme-mui'
import Avatar from '@mui/material/Avatar';
import { CardActionArea } from '@mui/material';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import StarIcon from '@mui/icons-material/Star';

interface ServiceCardProps {
  id: number,
  url_img: string;
  name: string;
  artist_id?: number;
  artist_url_img: string;
  artist_name: string;
  artist_rating: number;
  artist_qreviews: number;
  since_time: number;
  since_price: number;
};

function ServiceCard(props:ServiceCardProps) {

  return ( 
    <Card sx={{ maxWidth: 200 }}>
      <CardActionArea href={`/service/${props.id}`}>
        <CardMedia component="img" height="160"
          image={props.url_img} alt="portada" />
        <CardContent>
          <Typography variant="h5" component="div">
            Realizaré {props.name}
          </Typography>
          <Grid container spacing={1}>
            <Grid item xs={2}>
              <Avatar sx={{ bgcolor: themeMui.palette.primary.main, width: 24, height: 24 }}
                alt="Artist" src={props.artist_url_img}  />
            </Grid>
            <Grid item xs={6}>
              <Typography variant="h6" component="span" >
                {props.artist_name}
                </Typography>
            </Grid>
            <Grid item xs={4}>
              <ListItem>
                <ListItemIcon> <StarIcon color="info"/>  </ListItemIcon>
                <ListItemText primary={props.artist_rating + '('+props.artist_qreviews+')'}/>
              </ListItem>
            </Grid>
          </Grid>
          <Grid container spacing={1}>
            <Grid item xs={6}>
              <Typography component="span">
                <strong>{props.since_time}</strong> APROX.
              </Typography>
            </Grid>
            <Grid item xs={6}>
              <Typography component="span">DESDE <strong>${props.since_price}</strong></Typography>
            </Grid>
          </Grid>
        </CardContent>
      </CardActionArea>
    </Card>
  );
};

export default ServiceCard;
export type {ServiceCardProps};