using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Entities
{
    public class Propuesta:EntityBase

    {
        public int Artista_id { get; set; }
        public Artista Artista { get; set; }
        public int Cliente_id { get; set; }
        public Cliente Cliente { get; set; }
        public int tipo_pago_id { get; set; }
        public tipo_pago tipo_pago { get; set; }
        public int estado_propuesta_id { get; set; }
        public estado_propuesta estado_propuesta { get; set; }
        public int trabajo_id { get; set; }
        public trabajo trabajo { get; set; }
    }
}
