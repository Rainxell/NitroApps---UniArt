using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Dto
{
    public class Servicio_VariacionDto
    {
        public int Id { get; set; }
        public Boolean Incluir_editable { get; set; }
        public int Q_reviciones { get; set; }

        public TimeSpan Duracion_esperada { get; set; }

        public Decimal precio_base { get; set; }

        public String Url_imagen_referencia { get; set; }
    }
}
