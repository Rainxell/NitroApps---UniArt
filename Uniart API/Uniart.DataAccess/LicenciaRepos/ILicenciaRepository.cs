using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface ILicenciaRepository
    {
        Task<ICollection<Licencia>> GetCollection(string filter);

        Task<Licencia> Get(int id);
        Task Create(Licencia entity);

        Task Update(Licencia entity);

        Task Delete(int id);
    }
}
