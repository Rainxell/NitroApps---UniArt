import React, {useState} from 'react';
import request from './api';
import { Referencia } from '../models/referencia';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiReferenia={
    list: () => request.get<Referencia[]>("/Referencia"),
    add: (data: Referencia) => request.post("/Referencia",data),
    edit: (data: Referencia)=> request.put('/Referencia/${data.id}',data),
    delete: (id: number)=> request.delete('/Referencia/${id}'),
    detail: (id: number)=>request.get<Referencia>('/Referencia/${id}'),
};
export default apiReferenia;

//READ LIST
export const ListReferencia=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [referencia, setReferencia] = React.useState<Referencia[]>([]);
    function refreshReferencia(){
        apiReferenia.list().then((res)=>{
            to===undefined?setReferencia(res.slice(from,res.length))
            :setReferencia(res.slice(from,to));
            console.log('l referencia:', res);
        });
    }
    return {referencia, refreshReferencia};
};

//READ ONE 
export const GetReferencia = (id: number)=>{
    const [referencia, setReferencia] = React.useState<Referencia>(new Referencia);
    function refreshReferencia(){
        apiReferenia.detail(id).then((res)=>{
            setReferencia(res);
            console.log('i referencia:',res);
        }).catch(()=>{"no listó referencia"});
    }
    return {referencia, refreshReferencia};
};

//CREATE
export const CreateReferencia=(referencia:Referencia)=>{
    apiReferenia.add(referencia).then(()=>{    
    }).catch(()=>{console.log("no creó referencia")});
};

//UPDATE
export const UpdateReferencia = (referencia:Referencia)=>{
    apiReferenia.edit(referencia).then(()=>{
    }).catch(()=>{console.log("no actualizó referencia");});
};

//DELETE
export const DeleteReferencia=(id:number)=>{
    apiReferenia.delete(id).then(()=>{
    }).catch(()=>{"no eliminó referencia"});
};