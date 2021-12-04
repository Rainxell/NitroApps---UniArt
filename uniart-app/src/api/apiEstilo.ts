import React, {useState} from 'react';
import request from './api';
import { Estilo } from '../models/estilo';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiEstilo={
    list: () => request.get<Estilo[]>("/Estilo"),
    add: (data: Estilo) => request.post("/Estilo",data),
    edit: (data: Estilo)=> request.put('/Estilo/${data.id}',data),
    delete: (id: number)=> request.delete('/Estilo/${id}'),
    detail: (id: number)=>request.get<Estilo>('/Estilo/${id}'),
};
export default apiEstilo;

//READ LIST
export const ListEstilo=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [estilo, setEstilo] = React.useState<Estilo[]>([]);
    function refreshEstilo(){
        apiEstilo.list().then((res)=>{
            to===undefined?setEstilo(res.slice(from,res.length))
            :setEstilo(res.slice(from,to));
            console.log('l estilo:', res);
        });
    }
    return {estilo, refreshEstilo};
};

//READ ONE 
export const GetEstilo = (id: number)=>{
    const [estilo, setEstilo] = React.useState<Estilo>(new Estilo);
    function refreshEstilo(){
        apiEstilo.detail(id).then((res)=>{
            setEstilo(res);
            console.log('i estilo:',res);
        }).catch(()=>{"no listó estilo"});
    }
    return {estilo, refreshEstilo};
};

//CREATE
export const CreateEstilo=(estilo:Estilo)=>{
    apiEstilo.add(estilo).then(()=>{    
    }).catch(()=>{console.log("no creó estilo")});
};

//UPDATE
export const UpdateEstilo = (estilo:Estilo)=>{
    apiEstilo.edit(estilo).then(()=>{
    }).catch(()=>{console.log("no actualizó estilo");});
};

//DELETE
export const DeleteEstilo=(id:number)=>{
    apiEstilo.delete(id).then(()=>{
    }).catch(()=>{"no eliminó estilo"});
};