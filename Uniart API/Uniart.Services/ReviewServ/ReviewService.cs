using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.DataAccess;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<ReviewDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new ReviewDto
                {
                    Id = request.Id,
                    Rating_cliente = request.Rating_cliente,
                    Comentario = request.Comentario,
                    Fecha = request.Fecha,
                    Valor_Positivo = request.Valor_Positivo,
                    Valor_Negativo = request.Valor_Negativo
                })
                .ToList();

        }

        public async Task<ResponseDto<ReviewDto>> GetArtista(int id)
        {
            var response = new ResponseDto<ReviewDto>();
            var request = await _repository.Get(id);

            if (request == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new ReviewDto
            {
                Id = request.Id,
                Rating_cliente = request.Rating_cliente,
                Comentario = request.Comentario,
                Fecha = request.Fecha,
                Valor_Positivo = request.Valor_Positivo,
                Valor_Negativo = request.Valor_Negativo
            };

            response.Success = true;

            return response;
        }

        public async Task Create(ReviewDto request)
        {
            try
            {
                await _repository.Create(new Review()
                {
                    Id = request.Id,
                    Rating_cliente = request.Rating_cliente,
                    Comentario = request.Comentario,
                    Fecha = request.Fecha,
                    Valor_Positivo = request.Valor_Positivo,
                    Valor_Negativo = request.Valor_Negativo

                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(ReviewDto request)
        {
            await _repository.Update(new Review
            {

                Id = request.Id,
                Rating_cliente = request.Rating_cliente,
                Comentario = request.Comentario,
                Fecha = request.Fecha,
                Valor_Positivo = request.Valor_Positivo,
                Valor_Negativo = request.Valor_Negativo

            });
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
