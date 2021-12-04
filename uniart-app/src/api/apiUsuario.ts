import React, { useState } from 'react';
import { Usuario } from "../models/usuario";
import request from './api';

const apiUsuario = {
	list: () => request.get<Usuario[]>("/Usuario"),
	add: (data: Usuario) => request.post("/Usuario", data),
	edit: (data: Usuario) => request.put(`/Usuario/${data.id}`, data),
	delete: (id: number) => request.delete(`/Usuario/${id}`),
	detail: (id: number) => request.get<Usuario>(`/Usuario/${id}`),
};

export default apiUsuario;

//READ LIST 
export const ListUsuarios = (from?: number, to?: number) => {
	if (from === undefined) from = 0;
	const [users, setUsuarios] = React.useState<Usuario[]>([]);
	function refreshUsuarios() {
		apiUsuario.list().then((res) => {
			to === undefined ? setUsuarios(res.slice(from, res.length))
				: setUsuarios(res.slice(from, to));
			console.log('l users:', res);
		});
	}
	return { users, refreshUsuarios };
};

//READ ONE (DETAILS)
export const GetUsuario = (id: number) => {
	const [user, setUsuario] = React.useState<Usuario>(new Usuario);
	function refreshUsuario() {
		apiUsuario.detail(id).then((res) => {
			setUsuario(res);
			console.log('i user:', res);
		}).catch(() => { "no listo user" });
	}
	return { user, refreshUsuario };
};

//CREATE
export const CreateUsuario = (user: Usuario) => {
	apiUsuario.add(user).then(() => {
	}).catch(() => { console.log("no creo user") });
};

//UPDATE
export const UpdateUsuario = (user: Usuario) => {
	apiUsuario.edit(user).then(() => {
	}).catch(() => { console.log("no actualizo user"); });
};

//DELETE
export const DeleteUsuario = (id: number) => {
	apiUsuario.delete(id).then(() => {
	}).catch(() => { "no elimino user" });
};