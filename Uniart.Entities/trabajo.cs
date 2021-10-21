using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Entities
{
    public class trabajo:EntityBase
    {
        public int Cliente_id { get; set; }
        public Cliente Cliente { get; set; }
        public int duracion_esperada_id { get; set; }
        public duracion_esperada duracion_esperada { get; set; }
        public int complejidad_id { get; set; }
        public complejidad complejidad { get; set; }
        public int tipo_pago_id { get; set; }
        public tipo_pago tipo_pago { get; set; }
        public decimal monto_pago { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }
    }
}
