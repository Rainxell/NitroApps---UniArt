using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Envio:EntityBase
    {
        public Comision Comision_ { get; set; }
        
        [Required]
        public String Url_imagen_enviada { get; set; }

        [Required]
        public String Descripcion { get; set; }

        
    }
}
