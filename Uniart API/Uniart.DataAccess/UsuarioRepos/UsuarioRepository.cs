using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UniartDbContext _context;

        public UsuarioRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Usuario>> GetCollection(string filter)
        {
            var collection = await _context.Usuarios
                .Where(c => c.Nombre.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task Create(Usuario entity)
        {
            await _context.Set<Usuario>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Usuario entity)
        {
            _context.Set<Usuario>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }

        public async Task Delete(int id)
        {
            var usuarioTodelete = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarioTodelete);
            await _context.SaveChangesAsync();
            //_context.Entry(new Usuario
            //{
            //    Id = id
            //}).State = EntityState.Deleted;
            //await _context.SaveChangesAsync();
        }
    }
}
