import React, { useState } from 'react';
import { RedSocialArtista } from "../models/red_social_artista";
import request from './api';

const apiRedSocialArtista = {
	list: () => request.get<RedSocialArtista[]>("/RedSocialArtista"),
	add: (data: RedSocialArtista) => request.post("/RedSocialArtista", data),
	edit: (data: RedSocialArtista) => request.put(`/RedSocialArtista/${data.red_social_id}`, data),
	delete: (id: number) => request.delete(`/RedSocialArtista/${id}`),
	detail: (id: number) => request.get<RedSocialArtista>(`/RedSocialArtista/${id}`),
};
export default apiRedSocialArtista;

//READ LIST 
export const ListRedesSociales = (from?:number,to?:number) => {
	if (from === undefined) from = 0;
  const [redes_art, setRedes] = React.useState<RedSocialArtista[]>([]);
	function refreshRedesSociales(){
    apiRedSocialArtista.list().then((res) => {
		to === undefined ? setRedes(res.slice(from,res.length))
			: setRedes(res.slice(from,to));
			console.log('l redes de artista:',res);
    });
  }
	return { redes_art, refreshRedesSociales};
};

//READ ONE (DETAILS)
export const GetRedSocial = (id:number) => {
	const [redes_art, setRedes] = React.useState<RedSocialArtista>(new RedSocialArtista);
	function refreshRedSocial(){
		apiRedSocialArtista.detail(id).then((res)=>{
			setRedes(res);
			console.log('i red de artista:',res);
		}).catch( ()=>{"no listó red de artista"} );
	}
	return {redes_art,refreshRedSocial};
};

//CREATE
export const CreateRedesSociales = (redes_art:RedSocialArtista) => {
	apiRedSocialArtista.add(redes_art).then(()=>{
	}).catch( ()=>{console.log("no creó red de artista")} );
};

//UPDATE
export const UpdateRedesSociales = (redes_art:RedSocialArtista) => {
	apiRedSocialArtista.edit(redes_art).then(()=>{
	}).catch(() => { console.log("no actualizó red de artista");} );
};

//DELETE
export const DeleteRedesSociales = (id:number) => {
	apiRedSocialArtista.delete(id).then(()=>{
	}).catch(() => {"no eliminó red de artista"} );
};

