import React, {useState} from 'react';
import request from './api';
import { Comunicacion } from '../models/_mensaje_comunicacion';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiComunicacion={
    list: () => request.get<Comunicacion[]>("/Comunicacion"),
    add: (data: Comunicacion) => request.post("/Comunicacion",data),
    edit: (data: Comunicacion)=> request.put('/Comunicacion/${data.id}',data),
    delete: (id: number)=> request.delete('/Comunicacion/${id}'),
    detail: (id: number)=>request.get<Comunicacion>('/Comunicacion/${id}'),
};
export default apiComunicacion;

//READ LIST
export const ListComunicacion=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [comunicacion, setComunicacion] = React.useState<Comunicacion[]>([]);
    function refreshComunicacion(){
        apiComunicacion.list().then((res)=>{
            to===undefined?setComunicacion(res.slice(from,res.length))
            :setComunicacion(res.slice(from,to));
            console.log('l tecnica:', res);
        });
    }
    return {comunicacion, refreshComunicacion};
};

//READ ONE 
export const GetComunicacion = (id: number)=>{
    const [comunicacion, setComunicacion] = React.useState<Comunicacion>(new Comunicacion);
    function refreshComunicacion(){
        apiComunicacion.detail(id).then((res)=>{
            setComunicacion(res);
            console.log('i comunicacion:',res);
        }).catch(()=>{"no listó comunicacion"});
    }
    return {comunicacion, refreshComunicacion};
};

//CREATE
export const CreateComunicacion=(comunicacion:Comunicacion)=>{
    apiComunicacion.add(comunicacion).then(()=>{    
    }).catch(()=>{console.log("no creó comunicacion")});
};

//UPDATE
export const UpdateComunicacion = (comunicacion:Comunicacion)=>{
    apiComunicacion.edit(comunicacion).then(()=>{
    }).catch(()=>{console.log("no actualizó comunicacion");});
};

//DELETE
export const DeleteComunicacion=(id:number)=>{
    apiComunicacion.delete(id).then(()=>{
    }).catch(()=>{"no eliminó comunicacion"});
};