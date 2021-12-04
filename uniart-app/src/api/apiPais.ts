import React, { useState } from 'react'
import { Pais } from "../models/pais";
import request from './api';

const apiPais = {
	list: () => request.get<Pais[]>("/Pais"),
	//add: (data: Pais) => request.post("/Pais", data),
	//edit: (data: Pais) => request.put(`/Pais/${data.id}`, data),
	//delete: (id: number) => request.delete(`/Pais/${id}`),
	detail: (id: number) => request.get<Pais>(`/Pais/${id}`),
};

export default apiPais;


//READ LIST 
export const ListPaises = () => {
  const [paises, setPaises] = React.useState<Pais[]>([]);
	function refreshPaises(){
    apiPais.list().then((res) => {
      setPaises(res);
			console.log('paises:',res);
    });
  }
	return {paises,refreshPaises};
};

//READ ONE (DETAILS)
export const GetPais = (id: number) => {
	const [pais, setPais] = React.useState<Pais>(new Pais);
	function refreshPais() {
		apiPais.detail(id).then((res) => {
			setPais(res);
			console.log('i pais:', res);
		}).catch(() => { "no listo pais" });
	}
	return { pais, refreshPais };
};