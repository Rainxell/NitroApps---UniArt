using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uniart.Entities
{
    public class Chat:EntityBase
    {
       public Artista Artista_ { set; get; }
        
        public Usuario Usuario_ { set; get; }

    }
}
