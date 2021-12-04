using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public interface IArtistaService
    {
        Task<ICollection<ArtistaDto>> GetCollection(string filter);
        Task<Artista> GetArtista(int id);
        Task Create(ArtistaDto request);
        //Task Update(ArtistaDto request);
        Task Delete(int id);
    }
}
