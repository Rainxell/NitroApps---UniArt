import React from 'react';
import { useUser } from '../session/userContext';

function HSCart() {
  const {user, signup} = useUser();

  React.useEffect(()=>{
    console.log('desde cart', user);
  },[]);

  return (
    <div>
      
    </div>
  );
};

export default HSCart;
