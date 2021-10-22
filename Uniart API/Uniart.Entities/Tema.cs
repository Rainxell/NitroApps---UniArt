using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Tema:EntityBase
    {
        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }
        public IList<Servicio_Tema> Servicios_Temas { get; set; }
    }
}
