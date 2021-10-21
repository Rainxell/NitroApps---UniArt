using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Cuenta_Usuario: EntityBase
    {
        [Required]
        [StringLength(128)]
        public string user_name { get; set; }

        [Required]
        [StringLength(128)]
        public string password { get; set; }

        [Required]
        [StringLength(128)]
        public string email { get; set; }

        [Required]
        [StringLength(128)]
        public string nombre { get; set; }

        [Required]
        [StringLength(128)]
        public string apellido { get; set; }

    }
}
