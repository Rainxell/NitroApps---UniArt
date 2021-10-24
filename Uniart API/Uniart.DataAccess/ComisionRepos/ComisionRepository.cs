using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess.ComisionRepos
{
    public class ComisionRepository: IComisionRepository
    {
        private readonly UniartDbContext _context;

        public ComisionRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<Comision> GetComision(int id)
        {
            return await _context.Comisiones.FindAsync(id);
        }

        public async Task Create(Comision entity)
        {
            await _context.Set<Comision>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Comision entity)
        {
            _context.Set<Comision>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artistaToDelete = await _context.Comisiones.FindAsync(id);
            _context.Comisiones.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }

    }
}
