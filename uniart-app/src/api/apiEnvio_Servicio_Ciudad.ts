import React, { useState } from 'react';
import { EnvioServicioCiudad } from "../models/envio_servicio_ciudad";
import request from './api';

const apiEnvioServicioCiudad = {
	list: () => request.get<EnvioServicioCiudad[]>("/EnvioServicioCiudad"),
	add: (data: EnvioServicioCiudad) => request.post("/EnvioServicioCiudad", data),
	edit: (data: EnvioServicioCiudad) => request.put(`/EnvioServicioCiudad/${data.servicio_id}`, data),
	delete: (id: number) => request.delete(`/EnvioServicioCiudad/${id}`),
	detail: (id: number) => request.get<EnvioServicioCiudad>(`/EnvioServicioCiudad/${id}`),
};
export default apiEnvioServicioCiudad;

//READ LIST 
export const ListRedesSociales = (from?:number,to?:number) => {
	if (from === undefined) from = 0;
  const [envios, setEnvios] = React.useState<EnvioServicioCiudad[]>([]);
	function refreshRedesSociales(){
    apiEnvioServicioCiudad.list().then((res) => {
		to === undefined ? setEnvios(res.slice(from,res.length))
			: setEnvios(res.slice(from,to));
			console.log('l envios:',res);
    });
  }
	return { envios, refreshRedesSociales};
};

//READ ONE (DETAILS)
export const GetEnvioServicioCiudad = (id:number) => {
	const [envios, setEnvios] = React.useState<EnvioServicioCiudad>(new EnvioServicioCiudad);
	function refreshEnvioServicioCiudad(){
		apiEnvioServicioCiudad.detail(id).then((res)=>{
			setEnvios(res);
			console.log('i envio:',res);
		}).catch( ()=>{"no listó envio"} );
	}
	return {envios,refreshEnvioServicioCiudad};
};

//CREATE
export const CreateRedesSociales = (envios:EnvioServicioCiudad) => {
	apiEnvioServicioCiudad.add(envios).then(()=>{
	}).catch( ()=>{console.log("no creó envio")} );
};

//UPDATE
export const UpdateRedesSociales = (envios:EnvioServicioCiudad) => {
	apiEnvioServicioCiudad.edit(envios).then(()=>{
	}).catch(() => { console.log("no actualizó envio");} );
};

//DELETE
export const DeleteRedesSociales = (id:number) => {
	apiEnvioServicioCiudad.delete(id).then(()=>{
	}).catch(() => {"no eliminó envio"} );
};

