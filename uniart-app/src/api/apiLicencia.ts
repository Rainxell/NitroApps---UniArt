import React, {useState} from 'react';
import request from './api';
import { Licencia } from '../models/licencia';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiLicencia={
    list: () => request.get<Licencia[]>("/Licencia"),
    add: (data: Licencia) => request.post("/Licencia",data),
    edit: (data: Licencia)=> request.put('/Licencia/${data.id}',data),
    delete: (id: number)=> request.delete('/Licencia/${id}'),
    detail: (id: number)=>request.get<Licencia>('/Licencia/${id}'),
};
export default apiLicencia;

//READ LIST
export const ListLicencia=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [licencia, setLicencia] = React.useState<Licencia[]>([]);
    function refreshLicencia(){
        apiLicencia.list().then((res)=>{
            to===undefined?setLicencia(res.slice(from,res.length))
            :setLicencia(res.slice(from,to));
            console.log('l licencia:', res);
        });
    }
    return {licencia, refreshLicencia};
};

//READ ONE 
export const GetLicencia = (id: number)=>{
    const [licencia, setLicencia] = React.useState<Licencia>(new Licencia);
    function refreshLicencia(){
        apiLicencia.detail(id).then((res)=>{
            setLicencia(res);
            console.log('i licencia:',res);
        }).catch(()=>{"no listó Licencia"});
    }
    return {licencia, refreshLicencia};
};

//CREATE
export const CreateLicencia=(licencia:Licencia)=>{
    apiLicencia.add(licencia).then(()=>{    
    }).catch(()=>{console.log("no creó licencia")});
};

//UPDATE
export const UpdateLicencia = (licencia:Licencia)=>{
    apiLicencia.edit(licencia).then(()=>{
    }).catch(()=>{console.log("no actualizó licencia");});
};

//DELETE
export const DeleteLicencia=(id:number)=>{
    apiLicencia.delete(id).then(()=>{
    }).catch(()=>{"no eliminó licencia"});
};
