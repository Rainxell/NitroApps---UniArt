import React from 'react';
import { useUser } from '../session/userContext';

function ChatP() {
  const {user, signup} = useUser();

  React.useEffect(()=>{
    console.log('desde chat', user);
  },[]);

  return (
    <div>
      
    </div>
  );
};

export default ChatP;
