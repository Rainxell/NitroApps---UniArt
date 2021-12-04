using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Servicio : EntityBase
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }
        public int Artista_id { get; set; }

        public Artista Artista { get; set; }

        [Required]
        public TimeSpan Duracion_esperada { get; set; }

        [Required]
        public Decimal Precio_base { get; set; }

        [Required]
        public Int16 Rating { get; set; }

        [Required]
        public int Q_valoraciones { get; set; }

        [Required]
        public Boolean Es_virtual { get; set; }

        [Required]
        public int Porc_adelanto { get; set; }

        [Required]
        public Boolean acepta_rembolso { get; set; }

        public Estilo Estilo_ { get; set; }

        public Tecnica Tecnica_ { get; set; }

        [Required]
        [StringLength(2000)]
        public String Acerca_servicio { get; set; }

        public Licencia Licencia_ { get; set; }

        [Required]
        public int Q_reviciones { get; set; }
        
        public string url_imagen { get; set; }
        public IList<Servicio_Formato> Servicios_Formatos { get; set; }
        public IList<Servicio_Tema> Servicios_Temas { get; set; }
        public IList<Envio_Servicio_Ciudad> Envios_Servicios_Ciudades { get; set; }
        public IList<Comision> Comisiones { get; set; }
    }
}
