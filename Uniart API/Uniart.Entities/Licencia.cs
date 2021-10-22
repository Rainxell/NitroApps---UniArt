using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Licencia:EntityBase
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }
    }
}
