import React from 'react';
import { themeMui, whites } from '../../themes/theme-mui'
import Avatar from '@mui/material/Avatar';
import { CardActionArea } from '@mui/material';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Grid from '@mui/material/Grid';
import RoomIcon from '@mui/icons-material/Room';

interface ArtistCardProps {
  id: number;
  url_artist_img: string;
  url_cover_img: string;
  name: string;
  country: string;
  description: string;
};

function ArtistCard(props:ArtistCardProps) {
  //console.log('artista',props);
  
  return (
    <Card sx={{ maxWidth: 200 }}> 
      <CardActionArea href={'/'+props.name}>
        <CardMedia component="img" height="144"
          image={props.url_cover_img===''?
          `${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg`:
          props.url_cover_img}
        alt="portada" />
        <CardContent sx={{paddingTop: 0,}}>
          <Grid container spacing={1}>
            <Grid item xs={5}>
              <Avatar sx={{
                bgcolor: themeMui.palette.primary.main,
                width: 72, height: 72,
                marginLeft: "-0.75rem",
                marginTop: "-1rem",
                border: whites.light + " solid 4pt",
              }} src={props.url_artist_img}
                alt={props.name} />
            </Grid>
            <Grid item xs={7}>
              <Typography variant="h6" component="h6"> {props.name} </Typography>
              <ListItem>
                <ListItemIcon><RoomIcon color="secondary"/></ListItemIcon>
                <ListItemText primary={props.country} />
              </ListItem>
            </Grid>

            <Grid item xs={12}>
              <>{props.description}</>
            </Grid>
          </Grid>
        </CardContent>
      </CardActionArea>
    </Card>
  );
};

export default ArtistCard;
export type {ArtistCardProps};
export {};