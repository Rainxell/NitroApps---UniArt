using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Dto
{
    public class MensajeDto
    {
        public int Id { get; set; }
        public DateTime Hora_mensaje { get; set; }
        public string Texto_mensaje { set; get; }
    }
}
