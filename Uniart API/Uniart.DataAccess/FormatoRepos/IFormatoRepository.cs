using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IFormatoRepository
    {
        Task<ICollection<Formato>> GetCollection(string filter);

        Task<Formato> Get(int id);
        Task Create(Formato entity);

        Task Update(Formato entity);

        Task Delete(int id);

    }
}
