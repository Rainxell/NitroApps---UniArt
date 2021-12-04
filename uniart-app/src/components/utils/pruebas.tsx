import axios, { AxiosResponse } from "axios";
import React, { useEffect } from 'react'
import request from "../../api/api";
import apiArtista from '../../api/apiArtista'; //{ GetArtista, useFetchData } 
import { Artista } from '../../models/artista';

interface filterProps {
  allChecked: boolean,
  options: {checked:boolean,
            label:string,}[]
};

function Prueba1(props:{ a?:string,
  onChangeAll?:(e:React.ChangeEvent<HTMLInputElement>)=>void,
  onChangeItems?:(e:React.ChangeEvent<HTMLInputElement>)=>void,
  setFilters:(fp:filterProps)=>void,
  setA:(a:string)=>void,
  filters:filterProps }) {
  // TU ENVIAS Y RECIBES INCLUSO EVENTOS DEL PADRE
  const handleAllChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    props.filters.allChecked = event.target.checked;
    console.log(event.target.checked,props.filters.allChecked);
    props.filters.options.forEach((_,i)=>{
      props.filters.options[i].checked = event.target.checked;
    });
    props.setFilters(props.filters);
    console.log('h_all',props.filters,event.target.checked);
  }
  const handleItemsChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const k = +event.target.value;
    let c = props.filters;
    c.options[k].checked = event.target.checked;
    props.setFilters(c);
    console.log('h_items',props.filters,k,event.target.checked);
  }

  const [opts,setOpts] = React.useState([<></>]);
  React.useEffect(()=>{
    let opss = [<></>];
    props.filters.options.forEach((o,i)=>{
      opss.push(
      <label>{o.label}
        <input type="checkbox"
        value = {i}
        checked={o.checked}
        onChange={handleItemsChange}/>
      </label>)
    });
    setOpts(opss);
  },[props.filters]);
  // function allCheckedVal(){
  //   aC.options.forEach((o) => {
  //     if(o.checked === false) {return false;}
  //   });
  //   return true;
  // }

  // React.useEffect(()=>{
  //   aC.allChecked = allCheckedVal();
  //   setAC(aC);
  // },[aC.options,aC.allChecked===false]);
  // React.useEffect(()=>{
  //   aC.options.forEach((o,i)=>{
  //     aC.options[i].checked = aC.allChecked;
  //   });
  //   setAC(aC);
  // },[aC.allChecked]);
  
  return (
    <div>
      Todos <br/>
      <input type="checkbox"
      checked={props.filters.allChecked}
      onChange={handleAllChange}/>
      {opts}

      <br/><br/>
      {props.a}
      <input value={props.a} onChange={(e)=>{props.setA(e.target.value)}}/>
    </div>
  )
}


function Pruebas2(props:any) {
  const [artista, setArtista] = React.useState<Artista>(new Artista());
	function refreshArtista(id:number){
		apiArtista.detail(id).then((res)=>{
      let artist = new Artista();
      artist.nombre_usuario = res.nombre_usuario;
      artist.nombre = res.nombre;
      setArtista(artist);
			//setArtista(() => res);
			console.log('i artist:',artist,res);
		}).catch((err) => console.log(err));
	}

  React.useEffect(()=>{
    refreshArtista(12);
  },[]);
  
  return (<>
      <div>
        <h2>Doing stuff with data</h2>
        {artista.nombre_usuario} | 
        {artista.nombre} | 
      </div>
  </>)
}

interface Country{
  id: string,
  nombre: string,
}
function Pruebas(props:any) {
  const apiFilm = {
    list: () => request.get<Country[]>("/Pais"),
    add: (data: Country) => request.post("/Pais", data),
    edit: (data: Country) => request.put(`/Pais/${data.id}`, data),
    delete: (id: number) => request.delete(`/Pais/${id}`),
    detail: (id: number) => request.get<Country>(`/Pais/${id}`),
  };

  const [artista, setArtista] = React.useState<Artista>(new Artista());
	function refreshArtista(id:number){
		apiFilm.detail(id).then((res)=>{
      let artist = new Artista();
      artist.nombre_usuario = res.id+'';
      artist.nombre = res.nombre;
      setArtista(artist);
			//setArtista(() => res);
			console.log('i artist:',artist,res);
		}).catch((err) => console.log(err));
	}

  React.useEffect(()=>{
    refreshArtista(5);
  },[]);
  
  return (<>
      <div>
        <h2>Doing stuff with data</h2>
        {artista.nombre_usuario} | 
        {artista.nombre} | 
      </div>
  </>)
}

export default Pruebas
export {}
