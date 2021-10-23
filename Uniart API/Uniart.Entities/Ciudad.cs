using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Ciudad:EntityBase
    {        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public int Pais_id { get; set; }
        public Pais Pais { get; set; }
   
    }
}
