import React, {useState} from 'react';
import request from './api';
import { ServicioTema } from '../models/servicio_tema';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiServicioTema={
    list: () => request.get<ServicioTema[]>("/ServicioTema"),
    add: (data: ServicioTema) => request.post("/ServicioTema",data),
    edit: (data: ServicioTema)=> request.put('/ServicioTema/${data.id}',data),
    delete: (id: number)=> request.delete('/ServicioTema/${id}'),
    detail: (id: number)=>request.get<ServicioTema>('/ServicioTema/${id}'),
};
export default apiServicioTema;

//READ LIST
export const ListServicioTema=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [tema, setServicioTema] = React.useState<ServicioTema[]>([]);
    function refreshServivioTema(){
        apiServicioTema.list().then((res)=>{
            to===undefined?setServicioTema(res.slice(from,res.length))
            :setServicioTema(res.slice(from,to));
            console.log('l servicio tema:', res);
        });
    }
    return {tema, refreshServivioTema};
};

//READ ONE 
export const GetServicioTema = (id: number)=>{
    const [tema, setServicioTema] = React.useState<ServicioTema>(new ServicioTema);
    function refreshServivioTema(){
        apiServicioTema.detail(id).then((res)=>{
            setServicioTema(res);
            console.log('i servicio tema:',res);
        }).catch(()=>{"no listó servicio tema"});
    }
    return {tema, refreshServivioTema};
};

//CREATE
export const CreateServicioTema=(tema:ServicioTema)=>{
    apiServicioTema.add(tema).then(()=>{    
    }).catch(()=>{console.log("no creó servicio tema")});
};

//UPDATE
export const UpdateServicioTema = (tema:ServicioTema)=>{
    apiServicioTema.edit(tema).then(()=>{
    }).catch(()=>{console.log("no actualizó servicio tema");});
};

//DELETE
export const DeleteServicioTema=(id:number)=>{
    apiServicioTema.delete(id).then(()=>{
    }).catch(()=>{"no eliminó servicio tema"});
};