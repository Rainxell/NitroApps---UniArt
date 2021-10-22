using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Pais:EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
