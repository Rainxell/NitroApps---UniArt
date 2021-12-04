import React from 'react'
import { Chip, FormControl, Input, InputLabel} from '@mui/material';

interface ChipData {
  key: number;
  label: string;
}

function StackChips(props:{ id?:string, maxChips?:number,
  spacing?:number, maxHeight?:number, label?:string}) {

  const [value,setValue] = React.useState<string>('');
  const [chipData, setChipData] = React.useState<ChipData[]>([]);
  const [lastKey, setLastKey] = React.useState<number>(0);

  const handleDelete = (chipToDelete: ChipData) => () => {
    //console.log(chipData, chipToDelete);
    setChipData(chipData.filter((chip) => chip.key !== chipToDelete.key ));
  };
  
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (props.maxChips!==undefined && chipData.length > props.maxChips-1) {
      //throw new Error('LLegó al máximo de chips');
      return;
    }
    if (event.target.value === (" ")) {
      setValue('');
    }
    else if(/\s+$/.test(event.target.value)) { //si el ultimo es un espacio
      const newIndx = lastKey+1;
      setLastKey(newIndx);
      //console.log(chipData);
      setChipData([...chipData,{key:newIndx, label:event.target.value.trim()}]);
      setValue('');
    } else {
      setValue(event.target.value);
    }
  };

  const label = props.label === undefined? 'chip' : props.label;
  ///3
  return ( 
    <FormControl className="stack-chips">
      <InputLabel htmlFor={props.id}>{label}</InputLabel>
      <Input id={props.id} value={value}
      rows={props.maxHeight} placeholder={'Separar por espacios'}
      onChange={handleChange} startAdornment={
        <>
          {chipData.map((cd)=>{ return(
            <Chip label={cd.label} onDelete={ handleDelete(cd) }/>
          ) })}
        </>
      } sx={{flexWrap: "wrap"}}/>
    </FormControl>
    
  )
}

export default StackChips;
