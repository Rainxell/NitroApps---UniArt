using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Review:EntityBase
    {
        [Required]
        public Int16 Rating_cliente { get; set; }

        [Required]
        public String Comentario { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int Valor_Positivo { get; set; }

        [Required]
        public int Valor_Negativo { get; set; }
        public IList<Valoracion> Valoraciones { get; set; }

    }
}
