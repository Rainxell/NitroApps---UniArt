using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Contrato : EntityBase
    {
        public int tipo_pago_id { get; set; }
        public tipo_pago tipo_pago { get; set; }

        [Required]
        public DateTime fecha_inicio { get; set; }
        [Required]
        public DateTime fecha_fin { get; set; }

        public decimal monto_pago { get; set; }
    }
}
