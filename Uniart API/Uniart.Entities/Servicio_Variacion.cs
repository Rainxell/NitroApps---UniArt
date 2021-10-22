using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Servicio_Variacion:EntityBase
    {
        public Servicio Servicio_ { get; set; }

        public Boolean Incluir_editable { get; set; }

        public Licencia Licencia_ { get; set; }

        [Required]
        public int Q_reviciones { get; set; }

        [Required]
        public TimeSpan Duracion_esperada { get; set; }

        [Required]
        public Decimal precio_base { get; set; }

        [Required]
        public String Url_imagen_referencia { get; set; }

        public IList<Variacion_Detalle> Variacion_Detalles { get; set; }
    }
}
