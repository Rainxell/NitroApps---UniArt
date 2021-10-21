using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Mensaje:EntityBase
    {
        public int Artista_id { get; set; }
        public Artista Artista { get; set; }
        public int Cliente_id { get; set; }
        public Cliente Cliente { get; set; }
        public int Propuesta_id { get; set; }
        public Propuesta Propuesta { get; set; }
        public int estado_propuesta_id { get; set; }
        public estado_propuesta estado_propuesta { get; set; }
        public DateTime hora_mensaje { get; set; }

        [Required]
        public string texto_mensaje { get; set; }

    }
}
