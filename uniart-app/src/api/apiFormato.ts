import React, {useState} from 'react';
import request from './api';
import { Formato } from '../models/formato';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiFormato={
    list: () => request.get<Formato[]>("/Formato"),
    add: (data: Formato) => request.post("/Formato",data),
    edit: (data: Formato)=> request.put('/Formato/${data.id}',data),
    delete: (id: number)=> request.delete('/Formato/${id}'),
    detail: (id: number)=>request.get<Formato>('/Formato/${id}'),
};
export default apiFormato;

//READ LIST
export const ListFormato=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [formato, setFormato] = React.useState<Formato[]>([]);
    function refreshFormato(){
        apiFormato.list().then((res)=>{
            to===undefined?setFormato(res.slice(from,res.length))
            :setFormato(res.slice(from,to));
            console.log('l formato:', res);
        });
    }
    return {formato, refreshFormato};
};

//READ ONE 
export const GetFormato = (id: number)=>{
    const [formato, setFormato] = React.useState<Formato>(new Formato);
    function refreshFormato(){
        apiFormato.detail(id).then((res)=>{
            setFormato(res);
            console.log('i formato:',res);
        }).catch(()=>{"no listó formato"});
    }
    return {formato, refreshFormato};
};

//CREATE
export const CreateFormato=(formato:Formato)=>{
    apiFormato.add(formato).then(()=>{    
    }).catch(()=>{console.log("no creó formato")});
};

//UPDATE
export const UpdateFormato = (formato:Formato)=>{
    apiFormato.edit(formato).then(()=>{
    }).catch(()=>{console.log("no actualizó formato");});
};

//DELETE
export const DeleteFormato=(id:number)=>{
    apiFormato.delete(id).then(()=>{
    }).catch(()=>{"no eliminó formato"});
};