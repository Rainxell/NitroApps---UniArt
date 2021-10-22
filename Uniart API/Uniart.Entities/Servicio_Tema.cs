using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Servicio_Tema
    {
        public int Tema_id { get; set; }
        [ForeignKey("Tema_id")]
        public Tema Tema { get; set; }
        public int Servicio_id { get; set; }
        [ForeignKey("Servicio_id")]
        public Servicio Servicio { get; set; }
    }
}
