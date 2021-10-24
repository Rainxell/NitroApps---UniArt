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
    public class Servicio_VariacionService:IServicio_VariacionService
    {
        private readonly IServicio_VariacionRepository _repository;

        public Servicio_VariacionService(IServicio_VariacionRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Servicio_VariacionDto request)
        {
            try
            {
                await _repository.Create(new Servicio_Variacion()
                {
                    Id = request.Id,
                    Incluir_editable = request.Incluir_editable,
                    Q_reviciones = request.Q_reviciones,
                    Duracion_esperada = request.Duracion_esperada,
                    precio_base = request.precio_base,
                    Url_imagen_referencia=request.Url_imagen_referencia

                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ResponseDto<Servicio_VariacionDto>> Get(int id)
        {
            var response = new ResponseDto<Servicio_VariacionDto>();
            var entidad = await _repository.Get(id);

            if (entidad == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new Servicio_VariacionDto
            {
                Id = entidad.Id,
                Incluir_editable = entidad.Incluir_editable,
                Q_reviciones = entidad.Q_reviciones,
                Duracion_esperada = entidad.Duracion_esperada,
                precio_base = entidad.precio_base,
                Url_imagen_referencia = entidad.Url_imagen_referencia
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<Servicio_VariacionDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(request => new Servicio_VariacionDto
                {
                    Id = request.Id,
                    Incluir_editable = request.Incluir_editable,
                    Q_reviciones = request.Q_reviciones,
                    Duracion_esperada = request.Duracion_esperada,
                    precio_base = request.precio_base,
                    Url_imagen_referencia = request.Url_imagen_referencia
                })
                .ToList();
        }

        public async Task Update(Servicio_VariacionDto request)
        {
            await _repository.Update(new Servicio_Variacion
            {

                Id = request.Id,
                Incluir_editable = request.Incluir_editable,
                Q_reviciones = request.Q_reviciones,
                Duracion_esperada = request.Duracion_esperada,
                precio_base = request.precio_base,
                Url_imagen_referencia = request.Url_imagen_referencia

            });
        }
    }
}
