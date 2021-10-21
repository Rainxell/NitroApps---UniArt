using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class tipo_pago:EntityBase
    {
        [Required]
        [StringLength(128)]
        public string tipo_nombre { set; get; }
    }
}
