using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IEstiloRepository
    {
        Task<ICollection<Estilo>> GetCollection(string filter);

        Task<Estilo> Get(int id);
        Task Create(Estilo entity);

        Task Update(Estilo entity);

        Task Delete(int id);
    }
}
