using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uniart.Entities
{
    public class Usuario_Tarjeta
    {
        public int Tarjeta_id { get; set; }
        [ForeignKey("Tarjeta_id")]
        public Tarjeta Tarjeta { get; set; }

        public int Usuario_id { get; set; }
        [ForeignKey("Usuario_id")]
        public Usuario Usuario { get; set; }
    }
}
