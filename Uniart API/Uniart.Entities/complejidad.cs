using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class complejidad:EntityBase
    {
        [Required]
        [StringLength(255)]
        public string complejidad_text { set; get; }
    }
}
