using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities.identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(128)]
        public string Apellido { get; set; }

        public int Ciudad_id { get; set; }
        public Ciudad Ciudad_ { get; set; }

        [Required]
        [StringLength(128)]
        public string Url_foto_perfil { get; set; }

        [Required]
        public DateTime Fecha_registro { get; set; }
        public bool esArtista { get; set; }

        [StringLength(2000)]
        public string Descripcion { get; set; }
        [StringLength(128)]
        public string Url_foto_portada { get; set; }
        public byte Rating { get; set; }
        public int Q_valoraciones { get; set; }
        public List<ApplicationUserRole> UserRoles { get; set; }
        public IList<Usuario> usuarios { get; set; }
        public IList<Artista> artistas { get; set; }
    }
}
