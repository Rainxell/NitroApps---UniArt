using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Ciudad:EntityBase
    {
        public Pais Pais_ { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public IList<Envio_Servicio_Ciudad> Envios_Servicios_Ciudades { get; set; }
    }
}
