using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Dto
{
    public class ComisionDto
    {
        public int Id { get; set; }
        public Decimal Porc_avance { get; set; }
        public Decimal Monto_pago_inicial { get; set; }
        public Decimal Monto_pago_final { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public DateTime Fecha_entrega { get; set; }
    }
}
