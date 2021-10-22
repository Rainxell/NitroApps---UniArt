using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IPaisRepository
    {
        Task<ICollection<Pais>> GetCollection(string filter);

        Task<Pais> GetPais(int id);
        Task Create(Pais entity);

        Task Update(Pais entity);

        Task Delete(int id);
    }
}
