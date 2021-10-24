using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class UsuarioTarjetaRepository:IUsuarioTarjetaRepository
    {
        private readonly UniartDbContext _context;

        public UsuarioTarjetaRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task Create(Usuario_Tarjeta entity)
        {
            await _context.Set<Usuario_Tarjeta>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario_Tarjeta> Get(int userid, int tarjetaid)
        {
            return await _context.Usuarios_Tarjetas.FindAsync(userid, tarjetaid);
        }
    }
}
