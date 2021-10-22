using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Mensaje:EntityBase
    {
        public Chat Chat_ { get; set; }

        [Required]
        public DateTime Hora_mensaje { get; set; }

        [Required]
        [StringLength(2000)]
        public string Texto_mensaje { set; get; }
    }
}
