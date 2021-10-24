using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface IChatRepository
    {
        Task<Chat> GetChat(int id);
        Task Create(Chat entity);
    }
}
