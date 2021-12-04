import React from 'react';
import FacebookIcon from '@mui/icons-material/Facebook';
import InstagramIcon from '@mui/icons-material/Instagram';
import Grid from '@mui/material/Grid';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';

const styleList = { padding:"1rem", columnGap: "0.5rem",
                    display: "flex", justifyContent: "center", };
const styleItem = { display:"inline-flex", };

function Footer(props:{className?:string}) {
  return (
    <Grid container spacing={1} className={props.className}>
      <Grid item xs={6}>
        <List sx={styleList}>
          <ListItem sx={styleItem}><ListItemText primary="© 2021" /></ListItem>
          <ListItem sx={styleItem}><ListItemText primary="Condiciones de uso" /></ListItem>
          <ListItem sx={styleItem}><ListItemText primary="Privacidad" /></ListItem>
        </List>
      </Grid>
      <Grid item xs={6}>
        <List sx={styleList}>
          <ListItem sx={styleItem}><ListItemText primary="Síguenos en:" /></ListItem>
          <ListItem sx={styleItem}>
            <ListItemIcon> <FacebookIcon/> </ListItemIcon>
            <ListItemText primary="Facebook" />
          </ListItem>
          <ListItem sx={styleItem}>
            <ListItemIcon> <InstagramIcon/> </ListItemIcon>
            <ListItemText primary="Instagram" />
          </ListItem>
        </List>
      </Grid>
    </Grid>
  );
};

export default Footer;
