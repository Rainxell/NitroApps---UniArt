import React from 'react';
import { Grid, Input, Slider } from '@mui/material';

function DoubleRangeSlider(props: {min:number, max:number, current:number[],
  format:string, step?:number}) {

  const [value, setValue] = React.useState<number[]>(props.current);
  const handleChangeR = (event: Event, newValue: number | number[]) => {
    setValue(newValue as number[]);
  };
  const handleChangeRIMin = (event: React.ChangeEvent<HTMLInputElement>) => {
    let newMin = event.target.value === '' ? value[0] : Number(event.target.value);
    setValue([newMin, value[1]]);
  };
  const handleChangeRIMax = (event: React.ChangeEvent<HTMLInputElement>) => {
    let newMax = event.target.value === '' ? value[1] : Number(event.target.value);
    setValue([value[0],newMax]);
  };

  const handleBlurMin = (event: React.FocusEvent<HTMLInputElement>) => {
    let cval = event.target.value === '' ? 0 : Number(event.target.value);
    if (cval < props.min) {
      setValue([ props.min,value[1] ]);
    } else if (cval > props.max) {
      setValue([ value[1],props.max ]);
    }
  };
  const handleBlurMax = (event: React.FocusEvent<HTMLInputElement>) => {
    let cval = event.target.value === '' ? 0 : Number(event.target.value);
    if (cval < props.min) {
      setValue([ value[1],props.min ]);
    } else if (cval > props.max) {
      setValue([ value[0],props.max ]);
    }
  };

  const step = (props.step!=null)?props.step : (props.max - props.min)/20;

  return (
    <Grid container spacing={1} alignItems="center">
      <Grid item xs={3}>
        <Input value={value[0]} size="small" onChange={handleChangeRIMin} onBlur={handleBlurMin} 
        inputProps={{ step: step, min: props.min, max: props.max,
        type: 'number', 'aria-labelledby': 'input-slider',}}/>
      </Grid>
      <Grid item xs={5}>
        <Slider aria-label={'Price range'} size="small" value={value}
        min={props.min} step={step} max={props.max} onChange={handleChangeR}  
        valueLabelDisplay="auto" getAriaValueText={(p)=>{return `${props.format} ${p}`}} />
      </Grid>
      <Grid item xs={4}>
        <Input value={value[1]} size="small" onChange={handleChangeRIMax} onBlur={handleBlurMax}
        inputProps={{ step: step, min: props.min, max: props.max,
        type: 'number', 'aria-labelledby': 'input-slider',}}/>
      </Grid>
    </Grid>
  );
};

export default DoubleRangeSlider;
