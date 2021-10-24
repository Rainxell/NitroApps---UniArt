using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IServicio_VariacionRepository
    {
        Task<ICollection<Servicio_Variacion>> GetCollection(string filter);
        Task<Servicio_Variacion> Get(int id);
        Task Create(Servicio_Variacion entity);

        Task Update(Servicio_Variacion entity);

        Task Delete(int id);
    }
}
