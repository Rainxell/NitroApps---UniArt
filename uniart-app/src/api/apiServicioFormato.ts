import React, {useState} from 'react';
import request from './api';
import { ServicioFormato } from '../models/servicio_formato';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiServicioFormato={
    list: () => request.get<ServicioFormato[]>("/ServicioFormato"),
    add: (data: ServicioFormato) => request.post("/ServicioFormato",data),
    edit: (data: ServicioFormato)=> request.put('/ServicioFormato/${data.id}',data),
    delete: (id: number)=> request.delete('/ServicioFormato/${id}'),
    detail: (id: number)=>request.get<ServicioFormato>('/ServicioFormato/${id}'),
};
export default apiServicioFormato;

//READ LIST
export const ListServicioFormato=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [formato, setServicioFormato] = React.useState<ServicioFormato[]>([]);
    function refreshServicioFormato(){
        apiServicioFormato.list().then((res)=>{
            to===undefined?setServicioFormato(res.slice(from,res.length))
            :setServicioFormato(res.slice(from,to));
            console.log('l servicio formato:', res);
        });
    }
    return {formato, refreshServicioFormato};
};

//READ ONE 
export const GetServicioFormato = (id: number)=>{
    const [formato, setServicioFormato] = React.useState<ServicioFormato>(new ServicioFormato);
    function refreshServicioFormato(){
        apiServicioFormato.detail(id).then((res)=>{
            setServicioFormato(res);
            console.log('i servicio formato:',res);
        }).catch(()=>{"no listó servicio formato"});
    }
    return {formato, refreshServicioFormato};
};

//CREATE
export const CreateServicioFormato=(formato:ServicioFormato)=>{
    apiServicioFormato.add(formato).then(()=>{    
    }).catch(()=>{console.log("no creó servicio formato")});
};

//UPDATE
export const UpdateServicioFormato = (formato:ServicioFormato)=>{
    apiServicioFormato.edit(formato).then(()=>{
    }).catch(()=>{console.log("no actualizó servicio formato");});
};

//DELETE
export const DeleteServicioFormato=(id:number)=>{
    apiServicioFormato.delete(id).then(()=>{
    }).catch(()=>{"no eliminó servicio formato"});
};