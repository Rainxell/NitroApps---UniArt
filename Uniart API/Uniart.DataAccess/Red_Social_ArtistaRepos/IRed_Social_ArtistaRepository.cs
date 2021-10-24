using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IRed_Social_ArtistaRepository
    {
        Task<ICollection<Red_Social_Artista>> GetCollection(string filter);

        Task<Red_Social_Artista> Get(int id);
        Task Create(Red_Social_Artista entity);

        Task Update(Red_Social_Artista entity);

        Task Delete(int id);
    }
}
