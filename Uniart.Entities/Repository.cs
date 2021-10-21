using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Repository:EntityBase
    {
        public int Artista_id { get; set; }
        public Artista Artista { get; set; }

        [Required]
        public string Imagen { get; set; }

        public string name { set; get; }
    }
}
