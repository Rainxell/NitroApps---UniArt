using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Dto
{
    public class ArtistaDto:UsuarioDto
    {
        public string Descripcion { get; set; }
        public string Url_foto_portada { get; set; }
        public byte Rating { get; set; }
        public int Q_valoraciones { get; set; }
    }
}
