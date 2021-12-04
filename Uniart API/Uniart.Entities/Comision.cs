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
        public int Servicio_id { get; set; }
        public int Review_Usuario_id { get; set; }
        public Servicio Servicio_ { get; set; }
        public Review Review_id_Cliente { get; set; }
        public int Usuario_id { get; set; }
        public Usuario Usuario_ { get; set; }
        public int Servicio_Variacion_id { get; set; }
        public Servicio_Variacion Servicio_Variacio_ { get; set; }
        [Required]
        [StringLength(2000)]
        public string Descripcion { get; set; }



    }
}
