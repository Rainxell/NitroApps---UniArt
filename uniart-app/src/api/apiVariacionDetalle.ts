import React, {useState} from 'react';
import request from './api';
import { VariacionDetalle } from '../models/variacion_detalle';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';
import apiCaracteristicaOpcion from './apiCaracteristicaOpciones';

const apiVariacionDetalle={
    list: () => request.get<VariacionDetalle[]>("/VariacionDetalle"),
    add: (data: VariacionDetalle) => request.post("/VariacionDetalle",data),
    edit: (data: VariacionDetalle)=> request.put('/VariacionDetalle/${data.id}',data),
    delete: (id: number)=> request.delete('/VariacionDetalle/${id}'),
    detail: (id: number)=>request.get<VariacionDetalle>('/VariacionDetalle/${id}'),
};
export default apiVariacionDetalle;

//READ LIST
export const ListVariacionDetalle=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [variacion, setVariacionDetalle] = React.useState<VariacionDetalle[]>([]);
    function refreshVariacionDetalle(){
        apiVariacionDetalle.list().then((res)=>{
            to===undefined?setVariacionDetalle(res.slice(from,res.length))
            :setVariacionDetalle(res.slice(from,to));
            console.log('l variacion detalle:', res);
        });
    }
    return {variacion, refreshVariacionDetalle};
};

//READ ONE 
export const GetVariacionDetalle = (id: number)=>{
    const [variacion, setVariacionDetalle] = React.useState<VariacionDetalle>(new VariacionDetalle);
    function refreshVariacionDetalle(){
        apiVariacionDetalle.detail(id).then((res)=>{
            setVariacionDetalle(res);
            console.log('i variacion detalle:',res);
        }).catch(()=>{"no listó variacion detalle"});
    }
    return {variacion, refreshVariacionDetalle};
};

//CREATE
export const CreateVariacionDetalle=(variacion:VariacionDetalle)=>{
    apiVariacionDetalle.add(variacion).then(()=>{    
    }).catch(()=>{console.log("no creó variacion detalle")});
};

//UPDATE
export const UpdateVariacionDetalle = (variacion:VariacionDetalle)=>{
    apiVariacionDetalle.edit(variacion).then(()=>{
    }).catch(()=>{console.log("no actualizó variacion detalle");});
};

//DELETE
export const DeleteVariacionDetalle=(id:number)=>{
    apiVariacionDetalle.delete(id).then(()=>{
    }).catch(()=>{"no eliminó variacion detalle"});
};