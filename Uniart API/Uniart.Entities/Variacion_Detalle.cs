using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Variacion_Detalle
    {

        public int Servicio_Variacion_id { get; set; }
        [ForeignKey("Servicio_Variacion_id")]
        public Servicio_Variacion Servicio_Variacion { get; set; }

        public int Caracteristica_Opciones_id { get; set; }
        [ForeignKey("Caracteristica_Opciones_id")]
        public Caracteristica_Opciones Caracteristica_Opciones { get; set; }
    }
}
