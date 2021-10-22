using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Servicio_Formato
    {
        public int Formato_id { get; set; }
        public Formato Formato_{ get; set; }

        public int Servicio_id { get; set; }
        public Servicio Servicio_ { get; set; }
    }
}
