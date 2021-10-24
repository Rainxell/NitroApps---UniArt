using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IServicio_FormatoRepository
    {
        

        Task<Servicio_Formato> Get(int id, int id2);
        Task Create(Servicio_Formato entity);

        Task Update(Servicio_Formato entity);

        
    }
}
