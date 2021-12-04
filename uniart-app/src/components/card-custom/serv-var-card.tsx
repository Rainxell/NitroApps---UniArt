import { Paper } from '@mui/material'
import React from 'react'

interface RowAtributes {
  colIndx:string,
  value:any,
  componentEdit?: any,
  isDeletable?: boolean,
}


function ServVarCard(props:{list:RowAtributes[], id?:number}) {

  const [dataVals,setDataVals] = React.useState<RowAtributes[]>();
  const [lastIndex,setLastIndex] = React.useState<number>(0);

  return (
    <>
      
    </>
  )
}

export default ServVarCard
