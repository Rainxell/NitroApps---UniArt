import React, {useState} from 'react';
import request from './api';
import { ServicioCaracteristica } from '../models/servicio_caracteristica';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiServicioCaracteristica={
    list: () => request.get<ServicioCaracteristica[]>("/ServicioCaracteristica"),
    add: (data: ServicioCaracteristica) => request.post("/ServicioCaracteristica",data),
    edit: (data: ServicioCaracteristica)=> request.put('/ServicioCaracteristica/${data.id}',data),
    delete: (id: number)=> request.delete('/ServicioCaracteristica/${id}'),
    detail: (id: number)=>request.get<ServicioCaracteristica>('/ServicioCaracteristica/${id}'),
};
export default apiServicioCaracteristica;

//READ LIST
export const ListServicioCaracteristica=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [servicio, setServicioCaracteristica] = React.useState<ServicioCaracteristica[]>([]);
    function refreshServicioCaracteristica(){
        apiServicioCaracteristica.list().then((res)=>{
            to===undefined?setServicioCaracteristica(res.slice(from,res.length))
            :setServicioCaracteristica(res.slice(from,to));
            console.log('l licencia:', res);
        });
    }
    return {servicio, refreshServicioCaracteristica};
};

//READ ONE 
export const GetServicioCaracteristica = (id: number)=>{
    const [servicio, setServicioCaracteristica] = React.useState<ServicioCaracteristica>(new ServicioCaracteristica);
    function refreshServicioCaracteristica(){
        apiServicioCaracteristica.detail(id).then((res)=>{
            setServicioCaracteristica(res);
            console.log('i servicio caracteristica:',res);
        }).catch(()=>{"no listó servicio caracteristica"});
    }
    return {servicio, refreshServicioCaracteristica};
};

//CREATE
export const CreateServicioCaracteristica=(servicio:ServicioCaracteristica)=>{
    apiServicioCaracteristica.add(servicio).then(()=>{    
    }).catch(()=>{console.log("no creó servicio caracteristica")});
};

//UPDATE
export const UpdateServicioCaracteristica = (servicio:ServicioCaracteristica)=>{
    apiServicioCaracteristica.edit(servicio).then(()=>{
    }).catch(()=>{console.log("no actualizó servicio caracteristica");});
};

//DELETE
export const DeleteServicioCaracteristica=(id:number)=>{
    apiServicioCaracteristica.delete(id).then(()=>{
    }).catch(()=>{"no eliminó servicio caracteristica"});
};
