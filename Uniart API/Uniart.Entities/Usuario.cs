using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Uniart.Entities.identity;

namespace Uniart.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public ApplicationUser Usuario_ { get; set; } 
        //[Required]
        //[StringLength(128)]
        //public string Nombre_usuario { get; set; }

        //[Required]
        //[StringLength(128)]
        //public string Password { get; set; }

        //[Required]
        //[StringLength(128)]
        //public string Email { get; set; }

        //[Required]
        //[StringLength(128)]
        //public string Nombre { get; set; }

        //[Required]
        //[StringLength(128)]
        //public string Apellido { get; set; }

        //public int Ciudad_id { get; set; }
        //public Ciudad Ciudad_ { get; set; }

        //[Required]
        //[StringLength(128)]
        //public string Url_foto_perfil { get; set; }

        //[Required]
        //public DateTime Fecha_registro { get; set; }
        public IList<Usuario_Tarjeta> Usuarios_Tarjetas { get; set; }
        public IList<Valoracion> Valoraciones { get; set; }
        public IList<Comision> ComisionesU { get; set; }
       // public List<ApplicationUser> Users { get; set; }

    }
}
