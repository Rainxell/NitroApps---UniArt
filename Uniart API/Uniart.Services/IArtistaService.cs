using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IArtistaService
    {
        Task<ICollection<ArtistaDto>> GetCollection(string filter);
        Task<ResponseDto<ArtistaDto>> GetArtista(int id);

        Task Create(ArtistaDto request);

        Task Update(ArtistaDto request);

        Task Delete(int id);
    }
}
