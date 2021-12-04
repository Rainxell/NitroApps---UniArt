using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Dto
{
    public class ServicioDto
    {
        public int Id { get; set; }
        public int Artista_id { get; set; }
        public int Tecnica_id { get; set; }
        public int Licencia_id { get; set; }
        public string Nombre { get; set; }
        public TimeSpan Duracion_esperada { get; set; }
        public Decimal Precio_base { get; set; }
        public Int16 Rating { get; set; }
        public int Q_valoraciones { get; set; }
        public Boolean Es_virtual { get; set; }
        public int Porc_adelanto { get; set; }
        public Boolean acepta_rembolso { get; set; }
        public String Acerca_servicio { get; set; }
        public int Q_reviciones { get; set; }
        public string url_imagen { get; set; }
        
    }
}
