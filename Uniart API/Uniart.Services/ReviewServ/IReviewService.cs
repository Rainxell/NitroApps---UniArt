using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface IReviewService
    {
        Task<ICollection<ReviewDto>> GetCollection(string filter);
        Task<ResponseDto<ReviewDto>> GetArtista(int id);
        Task Create(ReviewDto request);
        Task Update(ReviewDto request);
        Task Delete(int id);
    }
}
