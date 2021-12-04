import React from 'react';
import { useUser } from '../session/userContext';

function Commissions() {
  const {user, signup} = useUser();

  React.useEffect(()=>{
    console.log('desde comisiones', user);
  },[]);
  return (
    <div>
      
    </div>
  );
};

export default Commissions;
