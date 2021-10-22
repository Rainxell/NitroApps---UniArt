using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Caracteristica_Opciones:EntityBase
    {
        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        public Servicio_Caracteristica Servicio_Caracteristica_ { get; set; }
        public IList<Variacion_Detalle> Variacion_Detalles { get; set; }

    }
}
