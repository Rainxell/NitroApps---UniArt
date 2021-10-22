using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Envio_Servicio_Ciudad
    {
        public int Servicio_id { get; set; }

        public int Ciudad_id { get; set; }

        [Required]
        public Decimal Costo_envio { get; set; }

        [Required]
        public String Direccion { get; set; }

        [ForeignKey("Servicio_id")]
        public Servicio Servicio { get; set; }
        [ForeignKey("Ciudad_id")]
        public Ciudad Ciudad { get; set; }

    }
}
