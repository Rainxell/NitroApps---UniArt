using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Uniart.Entities.identity;

namespace Uniart.Entities
{
    public class Artista
    {
        public int Id { get; set; }
        public ApplicationUser Artista_ { get; set; }
        //[Required]
        //[StringLength(2000)]
        //public string Descripcion { get; set; }
        //[Required]
        //[StringLength(128)]
        //public string Url_foto_portada { get; set; }
        //public byte Rating { get; set; }
        //public int Q_valoraciones { get; set; }
        public IList<Red_Social_Artista> Redes_Sociales_Artistas { get; set; }
        public IList<Servicio> Servicios { get; set; }
       // public List<ApplicationUser> Usuarios{ get; set; }
    }
}
