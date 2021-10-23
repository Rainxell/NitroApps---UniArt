using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class ArtistaRepository: IArtistaRepository
    {
        private readonly UniartDbContext _context;

        public ArtistaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Artista>> GetCollection(string filter)
        {
            var collection = await _context.Artistas
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Artista> GetArtista(int id)
        {
            return await _context.Artistas.FindAsync(id);
        }

        public async Task Create(Artista entity)
        {
            await _context.Set<Artista>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Artista entity)
        {
            _context.Set<Artista>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Artistas.FindAsync(id);
            _context.Artistas.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }

       
    }
}
