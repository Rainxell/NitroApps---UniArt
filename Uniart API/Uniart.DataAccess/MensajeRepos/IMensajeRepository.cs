using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IMensajeRepository
    {
        Task<ICollection<Mensaje>> GetCollection(string filter);

        Task<Mensaje> Get(int id);
        Task Create(Mensaje entity);

        Task Update(Mensaje entity);

        Task Delete(int id);
    }
}
