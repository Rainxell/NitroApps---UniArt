import React, { useState } from 'react';
import { Valoracion } from "../models/valoracion";
import request from './api';

const apiValoracion = {
	list: () => request.get<Valoracion[]>("/Valoracion"),
	add: (data: Valoracion) => request.post("/Valoracion", data),
	edit: (data: Valoracion) => request.put(`/Valoracion/${data.review_id}`, data),
	delete: (id: number) => request.delete(`/Valoracion/${id}`),
	detail: (id: number) => request.get<Valoracion>(`/Valoracion/${id}`),
};

export default apiValoracion;

//READ LIST 
export const ListValoraciones = (from?: number, to?: number) => {
	if (from === undefined) from = 0;
	const [valoraciones, setValoraciones] = React.useState<Valoracion[]>([]);
	function refreshValoraciones() {
		apiValoracion.list().then((res) => {
			to === undefined ? setValoraciones(res.slice(from, res.length))
				: setValoraciones(res.slice(from, to));
			console.log('l valoraciones:', res);
		});
	}
	return { valoraciones, refreshValoraciones };
};

//READ ONE (DETAILS)
export const GetValoracion = (id: number) => {
	const [valoracion, setValoracion] = React.useState<Valoracion>(new Valoracion);
	function refreshValoracion() {
		apiValoracion.detail(id).then((res) => {
			setValoracion(res);
			console.log('i valoracion:', res);
		}).catch(() => { "no listó valoracion" });
	}
	return { valoracion, refreshValoracion };
};

//CREATE
export const CreateValoracion = (valoracion: Valoracion) => {
	apiValoracion.add(valoracion).then(() => {
	}).catch(() => { console.log("no creó valoracion") });
};

//UPDATE
export const UpdateValoracion = (valoracion: Valoracion) => {
	apiValoracion.edit(valoracion).then(() => {
	}).catch(() => { console.log("no actualizó valoracion"); });
};

//DELETE
export const DeleteValoracion = (id: number) => {
	apiValoracion.delete(id).then(() => {
	}).catch(() => { "no eliminó valoracion" });
};