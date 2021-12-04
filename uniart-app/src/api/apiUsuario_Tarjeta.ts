import React, { useState } from 'react';
import { UsuarioTarjeta } from "../models/usuario_tarjeta";
import request from './api';

const apiUsuarioTarjeta = {
	list: () => request.get<UsuarioTarjeta[]>("/UsuarioTarjeta"),
	add: (data: UsuarioTarjeta) => request.post("/UsuarioTarjeta", data),
	edit: (data: UsuarioTarjeta) => request.put(`/UsuarioTarjeta/${data.tarjeta_id}`, data),
	delete: (id: number) => request.delete(`/UsuarioTarjeta/${id}`),
	detail: (id: number) => request.get<UsuarioTarjeta>(`/UsuarioTarjeta/${id}`),
};
export default apiUsuarioTarjeta;

//READ LIST 
export const ListUsuarioTarjetas = (from?:number,to?:number) => {
	if (from === undefined) from = 0;
  const [tarjetas_user, setUsuarioTarjetas] = React.useState<UsuarioTarjeta[]>([]);
	function refreshUsuarioTarjetas(){
    apiUsuarioTarjeta.list().then((res) => {
      to===undefined ? setUsuarioTarjetas(res.slice(from,res.length))
			:setUsuarioTarjetas(res.slice(from,to));
			console.log('l tarjetas:',res);
    });
  }
	return {tarjetas_user,refreshUsuarioTarjetas};
};

//READ ONE (DETAILS)
export const GetUsuarioTarjeta = (id:number) => {
	const [tarjeta_user, setUsuarioTarjeta] = React.useState<UsuarioTarjeta>(new UsuarioTarjeta);
	function refreshUsuarioTarjeta(){
		apiUsuarioTarjeta.detail(id).then((res)=>{
			setUsuarioTarjeta(res);
			console.log('i tarjeta:',res);
		}).catch( ()=>{"no listó tarjeta"} );
	}
	return {tarjeta_user,refreshUsuarioTarjeta};
};

//CREATE
export const CreateUsuarioTarjeta = (tarjeta_user:UsuarioTarjeta) => {
	apiUsuarioTarjeta.add(tarjeta_user).then(()=>{
	}).catch( ()=>{console.log("no creó tarjeta")} );
};

//UPDATE
export const UpdateUsuarioTarjeta = (tarjeta_user:UsuarioTarjeta) => {
	apiUsuarioTarjeta.edit(tarjeta_user).then(()=>{
	}).catch( ()=>{console.log("no actualizó tarjeta");} );
};

//DELETE
export const DeleteUsuarioTarjeta = (id:number) => {
	apiUsuarioTarjeta.delete(id).then(()=>{
	}).catch( ()=>{"no eliminó tarjeta"} );
};

