import React from 'react';
import { Divider, FormControl, IconButton, ListItem, ListItemText, TextField } from '@mui/material'
import DeleteIcon from '@mui/icons-material/Delete';
import StackChips from './stack-chips';

const ItemChips = (props:{index:number, id_parent?: string,
  labelParent?:string, labelChips?:string, maxChilds?:number,
  onClick?:React.MouseEventHandler<HTMLButtonElement>,
  options?:readonly any[], getOptionLabel?:(option:any)=>string,
  hideDel?:boolean, maxHeight?:number}, key:number)=>{ 
  
  //console.log('ss',props.index, key);

  return (<div>
    <ListItem >
      <ListItemText primary={<TextField fullWidth id={`${props.id_parent}`}
      label={`${props.labelParent}`} />}/>
      {props.hideDel !== false ? (
        <IconButton aria-label="delete"
        onClick={props.onClick} tabIndex={props.index}>
          <DeleteIcon/> 
        </IconButton>
      ):<></>}
    </ListItem>

    <FormControl required sx={{width:"100%"}} >
        <StackChips spacing={3} maxHeight={2} maxChips={props.maxChilds}
          label={props.labelChips}/>
    </FormControl>
    
    <br/><br/><br/>
    <Divider light /><br/>
  </div>)
};

export default ItemChips;


/*<Stack spacing={3}>
          <Autocomplete multiple id={`c-${propsNC.index}`} 
          limitTags={propsNC.limitTags}
          options={propsNC.options}
          getOptionLabel={propsNC.getOptionLabel}
          renderInput={(params) => (
            <TextField label={`${propsNC.labelChips}`} rows={propsNC.maxHeight}
            placeholder={propsNC.labelChips}  {...params} />
          )} />
        </Stack> */