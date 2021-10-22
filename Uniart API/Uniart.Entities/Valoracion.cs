using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Valoracion
    {
        public int Usuario_id { get; set; }
        [ForeignKey("Usuario_id")]
        public Usuario Usuario { get; set; }

        public int Review_id { get; set; }
        [ForeignKey("Review_id")]
        public Review Review { get; set; }
        [Required]
        public Boolean Es_like { get; set; }

    }
}
