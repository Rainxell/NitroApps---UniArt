using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess.EnvioRepos
{
    public class EnvioRepository: IEnvioRepository
    {
        private readonly UniartDbContext _context;

        public EnvioRepository(UniartDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Envio>> GetCollection(string filter)
        {
            var collection = await _context.Envios
                .Where(c => c.Descripcion.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Envio> GetEnvio(int id)
        {
            return await _context.Envios.FindAsync(id);
        }

        public async Task Create(Envio entity)
        {
            await _context.Set<Envio>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Envio entity)
        {
            _context.Set<Envio>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Envios.FindAsync(id);
            _context.Envios.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
