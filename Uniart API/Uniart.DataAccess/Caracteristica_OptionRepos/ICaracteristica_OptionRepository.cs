using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface ICaracteristica_OptionRepository
    {
        Task<ICollection<Caracteristica_Opciones>> GetCollection(string filter);

        Task<Caracteristica_Opciones> GetCaracteristica_Option(int id);
        Task Create(Caracteristica_Opciones entity);

        Task Update(Caracteristica_Opciones entity);

        Task Delete(int id);

    }
}
