using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public class ChatRepository : IChatRepository
    {
        private readonly UniartDbContext _context;

        public ChatRepository(UniartDbContext context)
        {
            _context = context;
        }

        public async Task<Chat> GetChat(int id)
        {
            return await _context.Chats.FindAsync(id);
        }

        public async Task Create(Chat entity)
        {
            await _context.Set<Chat>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
