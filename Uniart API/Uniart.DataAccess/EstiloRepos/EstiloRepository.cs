using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class EstiloRepository: IEstiloRepository
    {
        private readonly UniartDbContext _context;

        public EstiloRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Estilo>> GetCollection(string filter)
        {
            var collection = await _context.Estilos
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Estilo> Get(int id)
        {
            return await _context.Estilos.FindAsync(id);
        }

        public async Task Create(Estilo entity)
        {
            await _context.Set<Estilo>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Estilo entity)
        {
            _context.Set<Estilo>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Estilos.FindAsync(id);
            _context.Estilos.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }

    }
}
