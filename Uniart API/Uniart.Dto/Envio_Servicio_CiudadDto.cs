using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Dto
{
    public class Envio_Servicio_CiudadDto
    {
        public int Servicio_id { get; set; }
        public int Ciudad_id { get; set; }
        public Decimal Costo_envio { get; set; }
    }
}
