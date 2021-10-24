using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Dto
{
    public class TarjetaDto
    {
        public int Id { get; set; }
        public string Numero_tarjeta { get; set; }
        public string Nombre_completo { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public Int16 Cvc { get; set; }
    }
}
