using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class duracion_esperada:EntityBase
    {
        [Required]
        [StringLength(255)]
        public string duracion_text { set; get; }
    }
}
