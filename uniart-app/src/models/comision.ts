export class Comision {
  id: number = 0;
  usuario_id: number = 0;
  servicio_id: number = 0;
  porc_avance: number = 0;
  monto_pago_inicial: number = 0;
  monto_pago_final: number = 0;
  fecha_inicio:  Date = new Date();
  fecha_fin: Date = new Date();
  fecha_entrega: Date = new Date();
  review_id_artistaid: number = 0;
  review_id_clienteid: number = 0;
};