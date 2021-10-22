using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Comision: EntityBase
    {
        [Required]
        public Decimal Porc_avance { get; set; }
        
        [Required]
        public Decimal Monto_pago_inicial { get; set; }

        [Required]
        public Decimal Monto_pago_final { get; set; }

        [Required]
        public DateTime Fecha_inicio { get; set; }
        
        [Required]
        public DateTime Fecha_fin { get; set; }

        [Required]
        public DateTime Fecha_entrega { get; set; }

        public Review Review_id_Artista { get; set; }

        public Review Review_id_Cliente { get; set; }

    }
}
