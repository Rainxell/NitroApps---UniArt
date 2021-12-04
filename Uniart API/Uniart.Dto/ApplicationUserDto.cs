using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Dto
{
    public class ApplicationUserRegisterDto
    {
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Ciudad_id { get; set; }
        public string Url_foto_perfil { get; set; }
        public DateTime Fecha_registro { get; set; }
        [Required]
        public bool esArtista { get; set; }
        public string Descripcion { get; set; }
        public string Url_foto_portada { get; set; }
        public byte Rating { get; set; }
        public int Q_valoraciones { get; set; }
    }

    public class ApplicationUserLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
