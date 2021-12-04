import React, {useState} from 'react';
import request from './api';
import { Tecnica } from '../models/tecnica';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiTecnica={
    list: () => request.get<Tecnica[]>("/Tecnica"),
    add: (data: Tecnica) => request.post("/Tecnica",data),
    edit: (data: Tecnica)=> request.put('/Tecnica/${data.id}',data),
    delete: (id: number)=> request.delete('/Tecnica/${id}'),
    detail: (id: number)=>request.get<Tecnica>('/Tecnica/${id}'),
};
export default apiTecnica;

//READ LIST
export const ListTecnica=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [tecnica, setTecnica] = React.useState<Tecnica[]>([]);
    function refreshTecnica(){
        apiTecnica.list().then((res)=>{
            to===undefined?setTecnica(res.slice(from,res.length))
            :setTecnica(res.slice(from,to));
            console.log('l tecnica:', res);
        });
    }
    return {tecnica, refreshTecnica};
};

//READ ONE 
export const GetTecnica = (id: number)=>{
    const [tecnica, setTecnica] = React.useState<Tecnica>(new Tecnica);
    function refreshTecnica(){
        apiTecnica.detail(id).then((res)=>{
            setTecnica(res);
            console.log('i tecnica:',res);
        }).catch(()=>{"no listó tecnica"});
    }
    return {tecnica, refreshTecnica};
};

//CREATE
export const CreateTecnica=(tecnica:Tecnica)=>{
    apiTecnica.add(tecnica).then(()=>{    
    }).catch(()=>{console.log("no creó tecnica")});
};

//UPDATE
export const UpdateTecnica = (tecnica:Tecnica)=>{
    apiTecnica.edit(tecnica).then(()=>{
    }).catch(()=>{console.log("no actualizó tecnica");});
};

//DELETE
export const Deletetecnica=(id:number)=>{
    apiTecnica.delete(id).then(()=>{
    }).catch(()=>{"no eliminó tecnica"});
};