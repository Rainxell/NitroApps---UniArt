import React, { useState } from 'react';
import { Tarjeta } from "../models/tarjeta";
import request from './api';

const apiTarjeta = {
	list: () => request.get<Tarjeta[]>("/Tarjeta"),
	add: (data: Tarjeta) => request.post("/Tarjeta", data),
	edit: (data: Tarjeta) => request.put(`/Tarjeta/${data.id}`, data),
	delete: (id: number) => request.delete(`/Tarjeta/${id}`),
	detail: (id: number) => request.get<Tarjeta>(`/Tarjeta/${id}`),
};
export default apiTarjeta;

//READ LIST 
export const ListTarjetas = (from?:number,to?:number) => {
	if (from === undefined) from = 0;
  const [tarjetas, setTarjetas] = React.useState<Tarjeta[]>([]);
	function refreshTarjetas(){
    apiTarjeta.list().then((res) => {
      to===undefined ? setTarjetas(res.slice(from,res.length))
			:setTarjetas(res.slice(from,to));
			console.log('l tarjetas:',res);
    });
  }
	return {tarjetas,refreshTarjetas};
};

//READ ONE (DETAILS)
export const GetTarjeta = (id:number) => {
	const [tarjeta, setTarjeta] = React.useState<Tarjeta>(new Tarjeta);
	function refreshTarjeta(){
		apiTarjeta.detail(id).then((res)=>{
			setTarjeta(res);
			console.log('i tarjeta:',res);
		}).catch( ()=>{"no listó tarjeta"} );
	}
	return {tarjeta,refreshTarjeta};
};

//CREATE
export const CreateTarjeta = (tarjeta:Tarjeta) => {
	apiTarjeta.add(tarjeta).then(()=>{
	}).catch( ()=>{console.log("no creó tarjeta")} );
};

//UPDATE
export const UpdateTarjeta = (tarjeta:Tarjeta) => {
	apiTarjeta.edit(tarjeta).then(()=>{
	}).catch( ()=>{console.log("no actualizó tarjeta");} );
};

//DELETE
export const DeleteTarjeta = (id:number) => {
	apiTarjeta.delete(id).then(()=>{
	}).catch( ()=>{"no eliminó tarjeta"} );
};

