import React, {useState} from 'react';
import request from './api';
import { Envio } from '../models/envio';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiEnvio={
    list: () => request.get<Envio[]>("/Envio"),
    add: (data: Envio) => request.post("/Envio",data),
    edit: (data: Envio)=> request.put('/Envio/${data.id}',data),
    delete: (id: number)=> request.delete('/Envio/${id}'),
    detail: (id: number)=>request.get<Envio>('/Envio/${id}'),
};
export default apiEnvio;

//READ LIST
export const ListEnvios=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [envio, setEnvio] = React.useState<Envio[]>([]);
    function refreshEnvio(){
        apiEnvio.list().then((res)=>{
            to===undefined?setEnvio(res.slice(from,res.length))
            :setEnvio(res.slice(from,to));
            console.log('l Envio:', res);
        });
    }
    return {envio, refreshEnvio};
};

//READ ONE 
export const GetEnvio = (id: number)=>{
    const [envio, setEnvio] = React.useState<Envio>(new Envio);
    function refreshEnvio(){
        apiEnvio.detail(id).then((res)=>{
            setEnvio(res);
            console.log('i envio:',res);
        }).catch(()=>{"no listó nvio"});
    }
    return {envio, refreshEnvio};
};

//CREATE
export const CreateEnvio=(envio:Envio)=>{
    apiEnvio.add(envio).then(()=>{    
    }).catch(()=>{console.log("no creó envio")});
};

//UPDATE
export const UpdateEnvio = (envio:Envio)=>{
    apiEnvio.edit(envio).then(()=>{
    }).catch(()=>{console.log("no actualizó envio");});
};

//DELETE
export const DeleteEnvio=(id:number)=>{
    apiEnvio.delete(id).then(()=>{
    }).catch(()=>{"no eliminó envio"});
};