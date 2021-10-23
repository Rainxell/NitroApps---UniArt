using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess.Variacion_DetalleRepos
{
    public class Variacion_DetalleRepository : IVariacion_DetalleRepository
    {
        private readonly UniartDbContext _context;

        public Variacion_DetalleRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<Variacion_Detalle> Get(int SV_id, int CO_id)
        {
            return await _context.Variacion_Detalles.FindAsync(SV_id, CO_id);
        }

        public async Task Create(Variacion_Detalle entity)
        {
            await _context.Set<Variacion_Detalle>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Variacion_Detalle entity)
        {
            _context.Set<Variacion_Detalle>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
