import React, { useState } from 'react'
import { Ciudad } from "../models/ciudad";
import request from './api';

const apiCiudad = {
	list: () => request.get<Ciudad[]>("/Ciudad"),
	//add: (data: Ciudad) => request.post("/Ciudad", data),
	//edit: (data: Ciudad) => request.put(`/Ciudad/${data.id}`, data),
	//delete: (id: number) => request.delete(`/Ciudad/${id}`),
	detail: (id: number) => request.get<Ciudad>(`/Ciudad/${id}`),
};

export default apiCiudad;


//READ LIST 
export const ListCiudades = () => {
  const [ciudades, setCiudades] = React.useState<Ciudad[]>([]);
	function refreshCiudades(){
    apiCiudad.list().then((res) => {
      setCiudades(res);
			console.log('ciudades:',res);
    });
  }
	return {ciudades,refreshCiudades};
};

//READ ONE (DETAILS)
export const GetCiudad = (id: number) => {
	const [ciudad, setCiudad] = React.useState<Ciudad>(new Ciudad);
	function refreshCiudad() {
		apiCiudad.detail(id).then((res) => {
			setCiudad(res);
			console.log('i ciudad:', res);
		}).catch(() => { "no listó ciudad" });
	}
	return { ciudad, refreshCiudad };
};
