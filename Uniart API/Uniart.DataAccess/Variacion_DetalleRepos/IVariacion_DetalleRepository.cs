using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IVariacion_DetalleRepository
    { 
        Task<Variacion_Detalle> Get(int SV_id,int CO_id);
        Task Create(Variacion_Detalle entity);

        Task Update(Variacion_Detalle entity);
    }
}
