using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class CiudadRepository:ICiudadRepository
    {
        private readonly UniartDbContext _context;

        public CiudadRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Ciudad>> GetCollection(string filter)
        {
            var collection = await _context.Ciudades
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Ciudad> GetCiudad(int id)
        {
            return await _context.Ciudades.FindAsync(id);
        }

        public async Task Create(Ciudad entity)
        {
            await _context.Set<Ciudad>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Ciudad entity)
        {
            _context.Set<Ciudad>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Ciudad
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


    }
}

