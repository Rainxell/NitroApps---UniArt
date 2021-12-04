import React from 'react';
import { Grid, Typography, IconButton }
  from '@mui/material';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import ItemChips from '../../components/form/item-chips';

function ListItemChips(props:{id?:string,
  labelParent?:string, labelChilds?:string,
  minParents?:number, maxParents?:number ,minChilds?:number, maxChilds?:number,
  options?:readonly any[], getOptionLabel?:(option:any)=>string,
}) {

  

  const [elDel,setElDel] = React.useState<number|undefined>();
  const [lastIndex,setLastIndex] = React.useState<number>(0);
  
  const handleDelCurrent = (event:React.MouseEvent<HTMLButtonElement>) => {
    console.log("eliminar" , event.currentTarget.tabIndex);
    setElDel(event.currentTarget.tabIndex);
  }
  
  //
  const newParent = ()=>{
    return (<ItemChips key={lastIndex} index={lastIndex} onClick={handleDelCurrent}
      options={options} maxHeight={1} maxChilds={props.maxChilds}
      labelParent={props.labelParent} labelChips={props.labelChilds}
      getOptionLabel={props.getOptionLabel} hideDel={lastIndex!==0}/>);
};
const newIdx = ()=>{
  return (<Typography variant="h5"
          sx={{ display:"flex", alignItems:"center", height:"10rem"}}>
          <strong>{options.length}</strong>
          </Typography>);
}
    
const [options,setOptions] = React.useState([<></>]);
const [listIndex,setListIndex] = React.useState([<></>]);
    
const handleMoreChars = (event: React.MouseEvent) => {
  //console.log(':',options);
  setLastIndex(lastIndex+1);
};

React.useEffect(()=>{
  //se activa incluso cuando el evento es inicializado
  console.log('nuevo',lastIndex);
  setOptions([...options,newParent()]);
  setListIndex([...listIndex,newIdx()])
},[lastIndex]);

React.useEffect(() => {
  console.log('eliminando',elDel,options);
  if(elDel){ 
    //console.log('bb',options,elDel);
    if (options.length > 1){
      //console.log('aa',options,elDel);
      let x = options;
      x = x.filter((o, i) => o.key !== elDel); //index
      console.log('eliminado', x)
      setOptions(x);
      x = listIndex.filter((_, i) => true);
      x.pop()
      setListIndex(x);
  }}
}, [elDel]);

  return (
    <Grid container id={props.id} spacing={1} sx={{ rowGap:"1.5rem" }} >
      <Grid item xs={1}>{listIndex}</Grid>
      <Grid item xs={10} sx={{alignItems:"flex-start"}}>{options}</Grid>
      <Grid item xs={12}>
        <IconButton aria-label="more" onClick={handleMoreChars}
        disabled={(props.maxParents === undefined || options.length <= props.maxParents)?false:true}>
          <AddCircleIcon/>
        </IconButton>
      </Grid>
    </Grid>
  );
};

export default ListItemChips;
