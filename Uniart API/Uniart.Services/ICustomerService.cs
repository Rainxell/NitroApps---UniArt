using System;
using System.Collections.Generic;
using System.Text;
using Uniart.Dto;

namespace Uniart.Services
{
    public interface ICustomerService
    {
        ICollection<CustomerDto> GetCollection(string filter);

        CustomerDto GetCustomer(int id);
        void Create(CustomerDto entity);

        void Update(int id, CustomerDto entity);

        void Delete(int id);
    }
}
