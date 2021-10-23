using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Artista: Usuario
    {
        
        [Required]
        [StringLength(2000)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(128)]
        public string Url_foto_portada { get; set; }

        public byte Rating { get; set; }
        public int Q_valoraciones { get; set; }
        public IList<Red_Social_Artista> Redes_Sociales_Artistas { get; set; }
    }
}
