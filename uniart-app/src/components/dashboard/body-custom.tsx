import React, { ChangeEventHandler } from 'react';
import { Routes, Route } from 'react-router';
import HSCart from '../../pages/cart/cart';
import ChatP from '../../pages/chat/chat';
import Commissions from '../../pages/comissions/in-progress';
import Explore from '../../pages/explore/explore';
import LandingPage from '../../pages/landing/landing-page';
import Settings from '../../pages/user/settings-conn';
import ArtistProfile from '../../pages/user/artist-profile';
import Login from '../../pages/session/login';
import Signin from '../../pages/session/signin';
import NewService from '../../pages/service/new-service-sum';
import CRUDprueba from '../../api/probar_apis2';
import Pruebas from '../utils/pruebas';
import Service from '../../pages/service/service';
import Logout from '@mui/icons-material/Logout';
import Service2 from '../../pages/service/service2';

const BodyCustom = () => {
  // const fil = {
  //   allChecked: true,
  //   options: [
  //     {checked:true,label:"aaaa"},
  //     {checked:true,label:"bbbb"},
  //     {checked:true,label:"cc"},
  //   ]};
  // const[a,setA] = React.useState('wop');
  // const[aC,setAC] = React.useState(fil);

  // React.useEffect(()=>{
  //   console.log('uf',aC);
  // },[aC]);

  return (
    <Routes>
      <Route path="/" element={< LandingPage />} />
      <Route path="/explore" element={< Explore />} />
      <Route path="/chat" element={< ChatP />} />
      <Route path="/commissions" element={< Commissions />} />
      <Route path="/cart" element={< HSCart />} />
      <Route path="/login" element={< Login />} />
      <Route path="/logout" element={< Logout />} />
      <Route path="/signin" element={< Signin />} />
      <Route path="/settings" element={< Settings />} />
      <Route path="/new-service" element={< NewService />} />
      <Route path="/crud-prueba" element={<CRUDprueba/>} />
      <Route path="/:username" element={< ArtistProfile />} />
      <Route path="/service/:service" element={< Service />} />
    </Routes>
  );
};
//<Route path="/artist-profile" element={< ArtistProfile />} />
//<Route path="/pruebas" element={<Pruebas a={a} setA={setA} setFilters={setAC} filters={aC}/>} />
export default BodyCustom;
