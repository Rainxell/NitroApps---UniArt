import React from 'react';
import ReactDOM from 'react-dom';
//import { ThemeProvider } from '@mui/private-theming';
import { ThemeProvider } from '@mui/material/styles';
import { themeMui } from './themes/theme-mui';
import { BrowserRouter } from "react-router-dom";
import Header from './components/dashboard/header';
import BodyCustom from './components/dashboard/body-custom';
import './index.css';
//import { createBrowserHistory } from "history";
import { Usuario } from './models/usuario';
import {UserProvider} from './pages/session/userContext';

//const customHistory = createBrowserHistory();
//import reportWebVitals from './reportWebVitals';
  
ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <UserProvider>
      <ThemeProvider theme={themeMui}>
        <Header/>
        <BodyCustom />
      </ThemeProvider>
      </UserProvider>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
//reportWebVitals();
