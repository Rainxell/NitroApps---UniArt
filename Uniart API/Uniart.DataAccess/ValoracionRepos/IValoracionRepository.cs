using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IValoracionRepository
    {
        Task<Valoracion> Get(int userid, int reviewid);
        Task Create(Valoracion entity);
        Task Delete(int userid, int reviewid);
    }
}
