import React, {useState} from 'react';
import request from './api';
import { Review } from '../models/review';
import { ExpandOutlined } from '@mui/icons-material';
import { serializeStyles } from '@emotion/serialize';

const apiReview={
    list: () => request.get<Review[]>("/Review"),
    add: (data: Review) => request.post("/Review",data),
    edit: (data: Review)=> request.put('/Review/${data.id}',data),
    delete: (id: number)=> request.delete('/Review/${id}'),
    detail: (id: number)=>request.get<Review>('/Review/${id}'),
};
export default apiReview;

//READ LIST
export const ListReview=(from?:number,to?:number)=>{
    if(from===undefined) from=0;
    const [reviews, setReview] = React.useState<Review[]>([]);
    function refreshReviews(){
        apiReview.list().then((res)=>{
            to===undefined?setReview(res.slice(from,res.length))
            :setReview(res.slice(from,to));
            console.log('l review:', res);
        });
    }
    return {reviews, refreshReviews};
};

//READ ONE 
export const GetReview = (id: number)=>{
    const [review, setReview] = React.useState<Review>(new Review);
    function refreshReview(){
        apiReview.detail(id).then((res)=>{
            setReview(res);
            console.log('i review:',res);
        }).catch(()=>{"no listó review"});
    }
    return {review, refreshReview};
};

//CREATE
export const CreateReview=(review:Review)=>{
    apiReview.add(review).then(()=>{    
    }).catch(()=>{console.log("no creó review")});
};

//UPDATE
export const UpdateReview = (review:Review)=>{
    apiReview.edit(review).then(()=>{
    }).catch(()=>{console.log("no actualizó review");});
};

//DELETE
export const DeleteReview=(id:number)=>{
    apiReview.delete(id).then(()=>{
    }).catch(()=>{"no eliminó review"});
};