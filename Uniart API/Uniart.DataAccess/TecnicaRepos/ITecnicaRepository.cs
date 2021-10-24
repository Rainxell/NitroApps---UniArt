using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface ITecnicaRepository
    {
        Task<ICollection<Tecnica>> GetCollection(string filter);

        Task<Tecnica> Get(int id);
        Task Create(Tecnica entity);

        Task Update(Tecnica entity);

        Task Delete(int id);
    }
}
