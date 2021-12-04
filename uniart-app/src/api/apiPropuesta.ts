import React, {useState} from 'react';
import request from './api';
import { Propuesta } from '../models/propuesta';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiPropuesta={
    list: () => request.get<Propuesta[]>("/Propuesta"),
    add: (data: Propuesta) => request.post("/Propuesta",data),
    edit: (data: Propuesta)=> request.put('/Propuesta/${data.id}',data),
    delete: (id: number)=> request.delete('/Propuesta/${id}'),
    detail: (id: number)=>request.get<Propuesta>('/Propuesta/${id}'),
};
export default apiPropuesta;

//READ LIST
export const ListPropuesta=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [propuesta, setPropuesta] = React.useState<Propuesta[]>([]);
    function refreshPropuesta(){
        apiPropuesta.list().then((res)=>{
            to===undefined?setPropuesta(res.slice(from,res.length))
            :setPropuesta(res.slice(from,to));
            console.log('l propuesta:', res);
        });
    }
    return {propuesta, refreshPropuesta};
};

//READ ONE 
export const GetPropuesta = (id: number)=>{
    const [propuesta, setPropuesta] = React.useState<Propuesta>(new Propuesta);
    function refreshPropuesta(){
        apiPropuesta.detail(id).then((res)=>{
            setPropuesta(res);
            console.log('i propuesta:',res);
        }).catch(()=>{"no listó propuesta"});
    }
    return {propuesta, refreshPropuesta};
};

//CREATE
export const CreatePropuesta=(propuesta:Propuesta)=>{
    apiPropuesta.add(propuesta).then(()=>{    
    }).catch(()=>{console.log("no creó propuesta")});
};

//UPDATE
export const UpdatePropuesta = (propuesta:Propuesta)=>{
    apiPropuesta.edit(propuesta).then(()=>{
    }).catch(()=>{console.log("no actualizó propuesta");});
};

//DELETE
export const DeletePropuesta=(id:number)=>{
    apiPropuesta.delete(id).then(()=>{
    }).catch(()=>{"no eliminó propuesta"});
};