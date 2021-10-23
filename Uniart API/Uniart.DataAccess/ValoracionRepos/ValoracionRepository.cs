using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class ValoracionRepository: IValoracionRepository
    {
        private readonly UniartDbContext _context;

        public ValoracionRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task Create(Valoracion entity)
        {
            await _context.Set<Valoracion>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int userid, int reviewid)
        {
            var artistaToDelete = await _context.Artistas.FindAsync(userid,reviewid);
            _context.Artistas.Remove(artistaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Valoracion> Get(int userid, int reviewid)
        {
            return await _context.Valoraciones.FindAsync(userid,reviewid);
        }
    }
}
