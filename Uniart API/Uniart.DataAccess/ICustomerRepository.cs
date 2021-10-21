using System;
using System.Collections.Generic;
using System.Text;
using Uniart.Entities;

namespace Uniart.DataAccess
{
    public interface ICustomerRepository
    {
        ICollection<Cuenta_Usuario> GetCollection(string filter);

        Cuenta_Usuario GetItem(int id);
        void Create(Cuenta_Usuario entity);

        void Update(Cuenta_Usuario entity);

        void Delete(int id);

    }
}
