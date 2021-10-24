using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public Int16 Rating_cliente { get; set; }
        public String Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public int Valor_Positivo { get; set; }
        public int Valor_Negativo { get; set; }
    }
}
