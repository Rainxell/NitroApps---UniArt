import React from 'react';
import Grid from '@mui/material/Grid';
import Drawer from '@mui/material/Drawer';
import Typography from '@mui/material/Typography';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { whites } from '../../themes/theme-mui';
import DoubleRangeSlider from '../../components/form/double-range-slider';
import CheckParentAll from '../../components/form/check-all-group';
import StarIcon from '@mui/icons-material/Star';

interface checkOpt {
  value:number,
  label:string,
  checked:boolean
}
interface range {
  min:number,
  max:number,
}
export interface filterProps {
  orderBy: {
    options: {value:number, label:string}[],
    selected: number
  }
  themes: checkOpt[],
  styles: checkOpt[],
  techniques: checkOpt[],
  countries:  checkOpt[],
  ratingR: range,
  priceR: range,
  duration: range,
}


function Filter(props:{filters:filterProps,
  //handleChangeOrderBy:(event: SelectChangeEvent) => void,
  setFilters:(filters:filterProps)=>void,
}) {

  const handleChangeOB = (event: SelectChangeEvent) => {
    props.filters.orderBy.selected = +event.target.value;
    props.setFilters(props.filters);
  };

  const [expanded, setExpanded] = React.useState<string | false>('panel1');
  const handleChangeA =
    (panel: string) => (event: React.SyntheticEvent, isExpanded: boolean) => {
      setExpanded(isExpanded ? panel : false);
    };

  /*const [checked, setChecked] = React.useState([true, true]);
  const handleChange1 = (event: React.ChangeEvent<HTMLInputElement>) => {
    setChecked([event.target.checked, event.target.checked]);
  };*/

  return (
    <Drawer variant="permanent" sx={{ flexShrink: 0,
      [`& .MuiDrawer-paper`]: { backgroundColor: whites.main } }}>
      <Typography variant="h4">Ilustraciones</Typography>
      <br/>
      
      <FormControl>
        <InputLabel id="order-by-label">Ordenar por</InputLabel>
        <Select labelId="order-by-label" id="order-by"
          value={props.filters.orderBy.selected+''}
          onChange={handleChangeOB} label="Más recientes" >
          {props.filters.orderBy.options.map((o)=>{
            <MenuItem value={o.value}>{o.label}</MenuItem>
          })}
        </Select>
      </FormControl>
      <br/>
      
      <Accordion disableGutters  expanded={expanded === 'panel1'} onChange={handleChangeA('panel1')}>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content" id="panel1a-header" >
          <Typography>Sobre la ilustración</Typography>
        </AccordionSummary>
        <AccordionDetails>

          <Typography component="strong">Tema</Typography>
          <CheckParentAll id="Tema" list={props.filters.themes} />

          <Typography component="strong">Estilo</Typography>
          <CheckParentAll id="Estilo" list={props.filters.styles} /> 

          <Typography component="strong">Técnicas</Typography>
          <CheckParentAll id="Colores" list={props.filters.techniques} />
          </AccordionDetails>
          
        </Accordion>


        <Accordion disableGutters  expanded={expanded === 'panel2'} onChange={handleChangeA('panel2')}>
          <AccordionSummary expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content" id="panel1a-header" >
              <Typography>Sobre el vendedor</Typography>
          </AccordionSummary>
          <AccordionDetails> 

            <Typography component="strong">Pais</Typography>
            <CheckParentAll id="Pais" list={props.filters.countries} /> 
            
            <ListItem>
              <ListItemIcon><StarIcon color="info"/></ListItemIcon>
              <ListItemText><strong>Rating</strong></ListItemText>
            </ListItem>
            <DoubleRangeSlider
            min={props.filters.ratingR.min} max={props.filters.ratingR.max}
            current={[props.filters.ratingR.min,props.filters.ratingR.max]}
            step={1} format=""/>

          </AccordionDetails>
        </Accordion>

        <Accordion disableGutters  expanded={expanded === 'panel3'} onChange={handleChangeA('panel3')}>
          <AccordionSummary expandIcon={<ExpandMoreIcon />}
            aria-controls="panel2a-content" id="panel2a-header" >
              <Typography>Rango de Precio ($)</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <DoubleRangeSlider
            min={props.filters.priceR.min} max={props.filters.priceR.max}
            current={[props.filters.priceR.min,props.filters.priceR.max]}
            format="$/."/>
          </AccordionDetails>
        </Accordion>

        <Accordion disableGutters  expanded={expanded === 'panel4'} onChange={handleChangeA('panel4')}>
          <AccordionSummary expandIcon={<ExpandMoreIcon />}
            aria-controls="panel2a-content" id="panel2a-header" >
              <Typography>Rango de Duración</Typography>
          </AccordionSummary>
          <AccordionDetails>
            <DoubleRangeSlider
            min={props.filters.priceR.min} max={props.filters.priceR.max}
            current={[props.filters.priceR.min,props.filters.priceR.max]}
            format="D"/>
          </AccordionDetails>
        </Accordion>
    </Drawer >
  );
};

export default Filter;
