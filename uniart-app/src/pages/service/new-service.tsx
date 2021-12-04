import React, { useState } from 'react';
import { Button, Grid, Typography,
  Stepper, Step, StepLabel, Container, StepContent, Divider, Link } from '@mui/material';
import CancelIcon from '@mui/icons-material/Cancel';
import NewSGeneralConn from '../../api-conn/new-general-conn';
import NewSVariationsConn from '../../api-conn/new-variation-conn';
import FullFeaturedCrudGrid from '../../components/form/data-grid';
import { Formato } from '../../models/formato';
import { Estilo } from '../../models/estilo';
import { Tecnica } from '../../models/tecnica';
import { Tema } from '../../models/tema';
import { Licencia } from '../../models/licencia';
import { Servicio } from '../../models/servicio';
import { ServicioVariacion } from '../../models/servicio_variacion';
import { ServicioCaracteristica } from '../../models/servicio_caracteristica';
import { CaracteristicaOpciones } from '../../models/caracteristica_opciones';

interface NewServiceProps {
  service: Servicio,
  themes: Tema[],//Servicio Temas
  formats: Formato[],//Servicio Formatos
};

function NewService() {


  const stepsLabels = ["Características generales","Características específicas"];
  //const generalS = React.createRef(); //.useRef(<NewSGeneralConn/>);
  //const specificS = React.createRef(); //React.useRef(<NewSVariationsConn/>);

  const [activeStep, setActiveStep] = React.useState(0);
  const [skipped, setSkipped] = React.useState(new Set<number>());
  /*const [steps, setSteps] = React.useState([
  <NewSGeneralConn id="new-service" />, <NewSVariationsConn id="new-service"/>]);*/

  const isStepSkipped = (step: number) => { return skipped.has(step); };

  const handleNext = () => {
    let newSkipped = skipped;
    if (isStepSkipped(activeStep)) {
      newSkipped = new Set(newSkipped.values());
      newSkipped.delete(activeStep);
    }
    //activeStep == 0? setSteps([<></>,steps[1]]) : setSteps([steps[0],<></>]) 
    /*if (activeStep == 0) {
      let el = document.getElementById('new-service');
      if (el) { setSteps([<>{el.innerHTML}</>,steps[1]]); }
    }*/
    setActiveStep((prevActiveStep) => prevActiveStep + 1);
    setSkipped(newSkipped);
  };

  const handleBack = () => {
    //if (activeStep == 2) setStep(specificS);
    //if (activeStep == 2) setStep(specificS);
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };

  const handleSkip = () => {
    throw new Error("Completar el paso.");

    setActiveStep((prevActiveStep) => prevActiveStep + 1);
    setSkipped((prevSkipped) => {
      const newSkipped = new Set(prevSkipped.values());
      newSkipped.add(activeStep);
      return newSkipped;
    });
  };

  const handleReset = () => { setActiveStep(0); };


  return (
    <Container>
    <Grid container className="filter-up">
      <Grid item xs={4}>
        <Typography variant="h3">Publicar producto</Typography>
      </Grid>
      <Grid item xs={4}>
        <Stepper activeStep={activeStep} color="secondary">
          {stepsLabels.map((s, index) => {
            const stepProps: { completed?: boolean } = {};
            if (isStepSkipped(index)) {
              stepProps.completed = false;
            }
            return (
              <Step key={s} {...stepProps}>
                <StepLabel optional={false}>{s}</StepLabel>
              </Step>
            );
          })}
        </Stepper>
      </Grid>
      <Grid item xs={4}>
        <Link href="/artist-profile">
          <Button endIcon={<CancelIcon/>} variant="contained" color="error">
            Cancelar
          </Button>
        </Link>
      </Grid>
    </Grid>

    <br/><Divider/>

    {activeStep === stepsLabels.length ? (
      <React.Fragment>
        <Grid container>
          <Typography sx={{ mt: 2, mb: 1 }}> ¡Listo! </Typography>
        </Grid>
        <Button onClick={handleReset}>
          Nuevo Servicio
        </Button>
      </React.Fragment>
    ) : (
      <React.Fragment>
        <br/><br/>
        <NewSGeneralConn id="new-service" />
        <br/><br/>        
        
      </React.Fragment>
    )}

    </Container>
  );
};
/*
{activeStep === stepsLabels.length - 1 ? '' 
        : <Button onClick={handleNext} variant="contained"></Button>}
<br/> <Divider/> <br/><br/>

<Button onClick={handleNext} color="primary" variant="contained">
          {activeStep === stepsLabels.length - 1 ? '¡Publicar!' : 'Siguiente'}
        </Button>

<Button color="secondary" disabled={activeStep === 0} variant="contained"
        onClick={handleBack} sx={{ mr: 1 }} > 
          Retroceder
        </Button> */

//{steps[activeStep]}
//{steps.map((s,i)=>{ return i===activeStep? s:<></> })}
export default NewService;
