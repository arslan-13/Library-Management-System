using Library.Data.Interface;
using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class CustomerRepository : ICustomerInterface
    {
        private readonly LibraryDbContext context;

        public CustomerRepository(LibraryDbContext libraryDbContext)
        {
            context = libraryDbContext;
        }

        public Task<IEnumerable<Customer>> GetAllCustomer()
        {
            throw new NotImplementedException();
        }
        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
