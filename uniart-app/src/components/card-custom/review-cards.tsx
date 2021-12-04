import React from 'react';
import ReviewCard, { ReviewCardProps } from './review-card';
import { Grid, Pagination, } from '@mui/material';

function ReviewCards(props: {list:Array<ReviewCardProps>,max?:number}) {
  let end:number = (props.max === undefined)? 10 : props.max;
  if (end > props.list.length) { end = props.list.length; }
  const pagination = () => {
    let numpags = Math.round(end / 10);
    return numpags > 1 ?
      <Pagination count={10} showFirstButton showLastButton />
      :<></>;
  };

  return (
    <Grid container spacing={1} className="cards">
      { props.list.slice(0,end).map( (r)=>
        <ReviewCard {...r}/>
      ) }
      
      <br/><br/>
      { pagination }
    </Grid>
  );
};

export default ReviewCards;

/*const start:number = (props.min === undefined)? 0 : props.min;
   */