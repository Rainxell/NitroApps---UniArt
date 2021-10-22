using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface ICiudadRepository
    {
        Task<ICollection<Ciudad>> GetCollection(string filter);
        Task<Ciudad> GetCiudad(int id);
        Task Create(Ciudad entity);

        Task Update(Ciudad entity);

        Task Delete(int id);
    }
}
