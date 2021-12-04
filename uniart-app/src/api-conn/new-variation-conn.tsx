import React from 'react';
import NewVariation from '../pages/service/new-variation';

interface ServGralProps{
  name: string, //nombre servicio
  since_time: number,
  since_price: number
}

function NewSVariationsConn(props:{id?:string}) {

  return (
    <NewVariation name='aaa' since_time={10} since_price={111} />
  );
};

export default NewSVariationsConn;
