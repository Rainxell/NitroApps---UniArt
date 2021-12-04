using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Red_Social_Artista
    {
        public int Red_social_id { get; set;}
        [ForeignKey("Red_social_id")]
        public Red_Social Red_Social { get; set; }

        public int Artista_id { get; set; }
        [ForeignKey("Artista_id")]
        public Artista Artista_ { get; set; }

        [Required]
        [StringLength(64)]
        public string username { get; set; }
    }
}
