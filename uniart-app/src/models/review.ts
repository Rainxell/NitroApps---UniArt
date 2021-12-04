export class Review {
  id: number = 0;
  rating_cliente: number = 0;
  comentario: string = "";
  fecha: Date = new Date();
  valor_Positivo: number = 0;
  valor_Negativo: number = 0;
  //url_img_referencia?: string = `${process.env.PUBLIC_URL}/images/bgs/PortadaBg.svg`;
};