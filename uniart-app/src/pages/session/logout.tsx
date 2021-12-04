import React from 'react';
import { useNavigate } from 'react-router';
import { useUser } from './userContext';

const logout = () => {
  
  const {user, logout} = useUser();
  const navi = useNavigate();
  
  logout();
  navi('/explore', { replace: true });

  return (<></>);
};

export default logout;
