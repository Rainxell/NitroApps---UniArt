import React, {useState} from 'react';
import request from './api';
import { ServicioVariacion } from '../models/servicio_variacion';

const apiServicioVariacion={
    list: () => request.get<ServicioVariacion[]>("/ServicioVariacion"),
    add: (data: ServicioVariacion) => request.post("/ServicioVariacion",data),
    edit: (data: ServicioVariacion)=> request.put('/ServicioVariacion/${data.id}',data),
    delete: (id: number)=> request.delete('/ServicioVariacion/${id}'),
    detail: (id: number)=>request.get<ServicioVariacion>('/ServicioVariacion/${id}'),
};
export default apiServicioVariacion;

//READ LIST
export const ListServicioVariacion=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [servicio, setServicioVariacion] = React.useState<ServicioVariacion[]>([]);
    function refreshServicioVariacion(){
        apiServicioVariacion.list().then((res)=>{
            to===undefined?setServicioVariacion(res.slice(from,res.length))
            :setServicioVariacion(res.slice(from,to));
            console.log('l servicio variacion:', res);
        });
    }
    return {servicio, refreshServicioVariacion};
};

//READ ONE 
export const GetServicioVariacion = (id: number)=>{
    const [servicio, setServicioVariacion] = React.useState<ServicioVariacion>(new ServicioVariacion);
    function refreshServicioVariacion(){
        apiServicioVariacion.detail(id).then((res)=>{
            setServicioVariacion(res);
            console.log('i servicio variación:',res);
        }).catch(()=>{"no listó servicio variacion"});
    }
    return {servicio, refreshServicioVariacion};
};

//CREATE
export const CreateServicioVariacion=(servicio:ServicioVariacion)=>{
    apiServicioVariacion.add(servicio).then(()=>{    
    }).catch(()=>{console.log("no creó servicio variacion")});
};

//UPDATE
export const UpdateLicencia = (licencia:ServicioVariacion)=>{
    apiServicioVariacion.edit(licencia).then(()=>{
    }).catch(()=>{console.log("no actualizó servicio variacion");});
};

//DELETE
export const DeleteServicioVariacion=(id:number)=>{
    apiServicioVariacion.delete(id).then(()=>{
    }).catch(()=>{"no eliminó servicio variacion"});
};
