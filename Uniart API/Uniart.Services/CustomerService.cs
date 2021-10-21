using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uniart.DataAccess;
using Uniart.Dto;
using Uniart.Entities;

namespace Uniart.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public void Create(ICustomerRepository _repository)
        {
            throw new NotImplementedException();
        }

        public void Create(CustomerDto entity)
        {
            _repository.Create(new Cuenta_Usuario 
            {
                user_name = entity.user_name,
                password = entity.password,
                nombre = entity.nombre,
                apellido = entity.apellido,
                email = entity.email
                
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ICollection<CustomerDto> GetCollection(string filter)
        {
            var collection = _repository.GetCollection(filter?? string.Empty);
            return collection
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    user_name = c.user_name,
                    password =c.password,
                    nombre = c.nombre,
                    apellido = c.apellido,
                    email = c.email
                }).ToList();
        }

        public CustomerDto GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, CustomerDto entity)
        {
            _repository.Update(new Cuenta_Usuario
            {
                user_name = entity.user_name,
                password = entity.password,
                nombre = entity.nombre,
                apellido = entity.apellido,
                email = entity.email

            });
        }
    }
}
