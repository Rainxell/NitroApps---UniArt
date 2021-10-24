using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class Red_Social_ArtistaRepository: IRed_Social_ArtistaRepository
    {
        private readonly UniartDbContext _context;

        public Red_Social_ArtistaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Red_Social_Artista>> GetCollection(string filter)
        {
            var collection = await _context.Redes_Sociales_Artistas
                .Where(c => c.username.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Red_Social_Artista> Get(int id)
        {
            return await _context.Redes_Sociales_Artistas.FindAsync(id);
        }

        public async Task Create(Red_Social_Artista entity)
        {
            await _context.Set<Red_Social_Artista>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Red_Social_Artista entity)
        {
            _context.Set<Red_Social_Artista>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Redes_Sociales_Artistas.FindAsync(id);
            _context.Redes_Sociales_Artistas.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
