using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Propuesta:EntityBase

    {
        public Usuario Usuario_ { get; set; }
        
        public Servicio_Variacion Servicio_Variacio_ { get; set; }

        [Required]
        [StringLength(2000)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
    }
}
