using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class estado_propuesta:EntityBase
    {
        [Required]
        [StringLength(128)]
        public string nombre_estado { set; get; }
    }
}
