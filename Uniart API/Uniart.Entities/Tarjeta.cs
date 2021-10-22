using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Tarjeta : EntityBase
    {
        [Required]
        [StringLength(16)]
        public string Numero_tarjeta { get; set; }

        [Required]
        [StringLength(128)]
        public string Nombre_completo { get; set; }

        [Required]
        public DateTime Fecha_vencimiento { get; set; }

        [Required]
        public Int16 Cvc { get; set; }
        public IList<Usuario_Tarjeta> Usuarios_Tarjetas { get; set; }
    }
}
