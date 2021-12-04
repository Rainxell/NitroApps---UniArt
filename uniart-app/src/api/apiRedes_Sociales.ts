import React, { useState } from 'react';
import { RedSocial } from "../models/red_social";
import request from './api';

const apiRedSocial = {
	list: () => request.get<RedSocial[]>("/RedSocial"),
	add: (data: RedSocial) => request.post("/RedSocial", data),
	edit: (data: RedSocial) => request.put(`/RedSocial/${data.id}`, data),
	delete: (id: number) => request.delete(`/RedSocial/${id}`),
	detail: (id: number) => request.get<RedSocial>(`/RedSocial/${id}`),
};
export default apiRedSocial;

//READ LIST 
export const ListRedesSociales = (from?:number,to?:number) => {
	if (from === undefined) from = 0;
  const [redes, setRedes] = React.useState<RedSocial[]>([]);
	function refreshRedesSociales(){
    apiRedSocial.list().then((res) => {
		to === undefined ? setRedes(res.slice(from,res.length))
			: setRedes(res.slice(from,to));
			console.log('l redes:',res);
    });
  }
	return {redes, refreshRedesSociales};
};

//READ ONE (DETAILS)
export const GetRedSocial = (id:number) => {
	const [redes, setRedes] = React.useState<RedSocial>(new RedSocial);
	function refreshRedSocial(){
		apiRedSocial.detail(id).then((res)=>{
			setRedes(res);
			console.log('i red:',res);
		}).catch( ()=>{"no listó red"} );
	}
	return {redes,refreshRedSocial};
};

//CREATE
export const CreateRedesSociales = (redes:RedSocial) => {
	apiRedSocial.add(redes).then(()=>{
	}).catch( ()=>{console.log("no creó red")} );
};

//UPDATE
export const UpdateRedesSociales = (redes:RedSocial) => {
	apiRedSocial.edit(redes).then(()=>{
	}).catch(() => { console.log("no actualizó red");} );
};

//DELETE
export const DeleteRedesSociales = (id:number) => {
	apiRedSocial.delete(id).then(()=>{
	}).catch(() => {"no eliminó red"} );
};

