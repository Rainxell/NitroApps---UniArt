import React, {useState} from 'react';
import request from './api';
import { Comision } from '../models/comision';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiComision={
    list: () => request.get<Comision[]>("/Comision"),
    add: (data: Comision) => request.post("/Comision",data),
    edit: (data: Comision)=> request.put('/Comision/${data.id}',data),
    delete: (id: number)=> request.delete('/Comision/${id}'),
    detail: (id: number)=>request.get<Comision>('/Comision/${id}'),
};
export default apiComision;

//READ LIST
export const ListComision=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [comisiones, setComisiones] = React.useState<Comision[]>([]);
    function refreshComisiones(){
        apiComision.list().then((res)=>{
            to===undefined?setComisiones(res.slice(from,res.length))
            :setComisiones(res.slice(from,to));
            console.log('l Comision:', res);
        });
    }
    return {comisiones, refreshComisiones};
};

//READ ONE 
export const GetComision = (id: number)=>{
    const [comision, setComision] = React.useState<Comision>(new Comision);
    function refreshComision(){
        apiComision.detail(id).then((res)=>{
            setComision(res);
            console.log('i Comision:',res);
        }).catch(()=>{"no listó Comision"});
    }
    return {comision, refreshComision};
};

//CREATE
export const CreateComision=(comision:Comision)=>{
    apiComision.add(comision).then(()=>{    
    }).catch(()=>{console.log("no creó Comision")});
};

//UPDATE
export const UpdateComision = (comision:Comision)=>{
    apiComision.edit(comision).then(()=>{
    }).catch(()=>{console.log("no actualizó Comision");});
};

//DELETE
export const DeleteComision=(id:number)=>{
    apiComision.delete(id).then(()=>{
    }).catch(()=>{"no eliminó Comision"});
};