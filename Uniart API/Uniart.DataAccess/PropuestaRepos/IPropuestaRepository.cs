using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IPropuestaRepository
    {
        Task<ICollection<Propuesta>> GetCollection(string filter);

        Task<Propuesta> Get(int id);
        Task Create(Propuesta entity);

        Task Update(Propuesta entity);

        Task Delete(int id);
    }
}
