using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IServicio_CaracteristicaRepository
    {
        Task<ICollection<Servicio_Caracteristica>> GetCollection(string filter);

        Task<Servicio_Caracteristica> Get(int id);
        Task Create(Servicio_Caracteristica entity);

        Task Update(Servicio_Caracteristica entity);

        Task Delete(int id);
    }
}
