import React from 'react';
import { Avatar, Card, CardContent, CardMedia, Grid, ListItem, ListItemIcon, ListItemText, Typography }
  from '@mui/material';
import { themeMui, blacks } from '../../themes/theme-mui';
import StarIcon from '@mui/icons-material/Star';
import Checkbox from '@mui/material/Checkbox';
import ThumbUpOlIcon from '@mui/icons-material/ThumbUpAltOutlined';
import ThumbDownOlIcon from '@mui/icons-material/ThumbDownAltOutlined';
import ThumbUpFrIcon from '@mui/icons-material/ThumbUpAltRounded';
import ThumbDownFrIcon from '@mui/icons-material/ThumbDownAltRounded';


interface ReviewCardProps {
  id: number,
  user_url_img?: string,
  user_name?: string,
  user_rating?: number,
  user_qreviews?: number,
  service_time_diff?: string,
  user_country?: string,
  service_details?: {question:string, answer:string}[],
  review: string,
  valor_usuario?: number,
  valor_positivo?: number,
  valor_negativo?: number,
  url_img?: string
};

function ReviewCard(review:ReviewCardProps) {

  const [like, setLike] = React.useState<string>(review.valor_usuario+'');
  const handleChangeL = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (!event.target.checked){ setLike(''); }
    else { setLike(event.target.value) };
  };

  const controlProps = (item: string) => ({
    checked: like === item,
    onChange: handleChangeL,
    value: item,
    name: 'valoracion',
    inputProps: { 'aria-label': item },
  });

  return (
    <Card sx={{ display: "flex" }}>
        <CardContent>
          <Grid container spacing={2}>
            <Grid item xs={8}>
              <ListItem>
                <ListItemIcon>
                  <Avatar sx={{ bgcolor: themeMui.palette.secondary.main, width: 24, height: 24 }}
                  alt="Usuario" src={review.user_url_img}  />
                </ListItemIcon>
                <ListItemText primary={ <Typography variant="h5"> {review.user_name} </Typography>}/>
                <ListItemIcon> <StarIcon color="info"/>  </ListItemIcon>
                <ListItemText primary={"*/-"}/>
              </ListItem>
            </Grid>
            <Grid item xs={4} sx={{ color: blacks.light, fontSize: "0.9em", }}>
              Hace {review.service_time_diff} | {review.user_country}
            </Grid>
          </Grid>

          

          <Typography component="p">
            {review.review}
          </Typography>

          <Grid container spacing={1}>
            <Grid item xs={2}>
              {review.valor_positivo}
              <Checkbox {...controlProps('1')}
              icon={<ThumbUpOlIcon/>} checkedIcon={<ThumbUpFrIcon/>} />
            </Grid>
            <Grid item xs={2}>
              {review.valor_negativo}
              <Checkbox {...controlProps('-1')}
              icon={<ThumbDownOlIcon/>} checkedIcon={<ThumbDownFrIcon/>} />
            </Grid>
          </Grid>

        </CardContent>
        <CardMedia component="img"  style={{width:"33%",}}
          image={review.url_img} alt="portada" />
    </Card>
  );
};


// {review.service_details.map((q,i)=>{ return (
//   <ListItem>
//     <ListItemIcon><strong>{q.question}</strong></ListItemIcon>
//     <ListItemText primary={q.answer}/>
//   </ListItem>
// )})}

export default ReviewCard;
export type {ReviewCardProps};
