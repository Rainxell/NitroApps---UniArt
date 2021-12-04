using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IServicioRepository
    {
        Task<ICollection<Servicio>> GetCollection(string filter);

        Task<Servicio> Get(int id);
        Task Create(Servicio entity);

        Task Update(Servicio entity);

        Task Delete(int id);
        Task<ICollection<Servicio>> GetServxArtista(int id);
    }
}
