import React, {useState} from 'react';
import request from './api';
import { Tema } from '../models/tema';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiTema={
    list: () => request.get<Tema[]>("/Tema"),
    add: (data: Tema) => request.post("/Tema",data),
    edit: (data: Tema)=> request.put('/Tema/${data.id}',data),
    delete: (id: number)=> request.delete('/Tema/${id}'),
    detail: (id: number)=>request.get<Tema>('/Tema/${id}'),
};
export default apiTema;

//READ LIST
export const ListTema=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [temas, setTemas] = React.useState<Tema[]>([]);
    function refreshTemas(){
        apiTema.list().then((res)=>{
            to===undefined?setTemas(res.slice(from,res.length))
            :setTemas(res.slice(from,to));
            console.log('l tema:', res);
        });
    }
    return {temas, refreshTemas};
};

//READ ONE 
export const GetTema = (id: number)=>{
    const [tema, setTema] = React.useState<Tema>(new Tema);
    function refreshTema(){
        apiTema.detail(id).then((res)=>{
            setTema(res);
            console.log('i tema:',res);
        }).catch(()=>{"no listó tema"});
    }
    return {tema, refreshTema};
};

//CREATE
export const CreateTema=(tema:Tema)=>{
    apiTema.add(tema).then(()=>{    
    }).catch(()=>{console.log("no creó tema")});
};

//UPDATE
export const UpdateTema = (tema:Tema)=>{
    apiTema.edit(tema).then(()=>{
    }).catch(()=>{console.log("no actualizó tema");});
};

//DELETE
export const DeleteTema=(id:number)=>{
    apiTema.delete(id).then(()=>{
    }).catch(()=>{"no eliminó tema"});
};