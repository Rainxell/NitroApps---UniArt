import React, {useState} from 'react';
import request from './api';
import { CaracteristicaOpciones } from '../models/caracteristica_opciones';

const apiCaracteristicaOpcion={
    list: () => request.get<CaracteristicaOpciones[]>("/CaracteristicaOpciones"),
    add: (data: CaracteristicaOpciones) => request.post("/CaracteristicaOpciones",data),
    edit: (data: CaracteristicaOpciones)=> request.put('/CaracteristicaOpciones/${data.id}',data),
    delete: (id: number)=> request.delete('/CaracteristicaOpciones/${id}'),
    detail: (id: number)=>request.get<CaracteristicaOpciones>('/CaracteristicaOpciones/${id}'),
};
export default apiCaracteristicaOpcion;

//READ LIST
export const ListCaracteristicaOpcion=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [caracteristica, setCaracteristicaOpcion] = React.useState<CaracteristicaOpciones[]>([]);
    function refreshCaracteristicaOpcion(){
        apiCaracteristicaOpcion.list().then((res)=>{
            to===undefined?setCaracteristicaOpcion(res.slice(from,res.length))
            :setCaracteristicaOpcion(res.slice(from,to));
            console.log('l caracteristica opcion:', res);
        });
    }
    return {caracteristica, refreshCaracteristicaOpcion};
};

//READ ONE 
export const GetCaracteristicaOpcion = (id: number)=>{
    const [caracteristica, setCaracteristicaOpcion] = React.useState<CaracteristicaOpciones>(new CaracteristicaOpciones);
    function refreshCaracteristicaOpcion(){
        apiCaracteristicaOpcion.detail(id).then((res)=>{
            setCaracteristicaOpcion(res);
            console.log('i caracteristica opcion:',res);
        }).catch(()=>{"no listó caracteristica opcion"});
    }
    return {caracteristica, refreshCaracteristicaOpcion};
};

//CREATE
export const CreateCaracteristicaOpcion=(caracteristica:CaracteristicaOpciones)=>{
    apiCaracteristicaOpcion.add(caracteristica).then(()=>{    
    }).catch(()=>{console.log("no creó caracteristica opcion")});
};

//UPDATE
export const UpdateCaracteristicaOpcion = (caracteristica:CaracteristicaOpciones)=>{
    apiCaracteristicaOpcion.edit(caracteristica).then(()=>{
    }).catch(()=>{console.log("no actualizó caracteristica opcion");});
};

//DELETE
export const DeleteCaracteristicaOpcion=(id:number)=>{
    apiCaracteristicaOpcion.delete(id).then(()=>{
    }).catch(()=>{"no eliminó caracteristica opcion"});
};
