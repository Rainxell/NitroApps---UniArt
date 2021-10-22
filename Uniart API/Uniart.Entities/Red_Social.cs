using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Red_Social:EntityBase
    {
        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }
        public IList<Red_Social_Artista> Redes_Sociales_Artistas { get; set; }
    }
}
