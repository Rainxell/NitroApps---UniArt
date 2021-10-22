using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IArtistaRepository
    {
        Task<ICollection<Artista>> GetCollection(string filter);

        Task<Artista> GetArtista(int id);
        Task Create(Artista entity);

        Task Update(Artista entity);

        Task Delete(int id);
    }
}
