using Library.Data.Interface;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LibraryDbContext cntx;

        public CustomerRepository(LibraryDbContext libraryDbContext)
        {
            cntx = libraryDbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await cntx.CustomersTbl.ToListAsync();
        }
        public void Add(Customer customer)
        {
            cntx.CustomersTbl.Add(customer);
        }

        public void Delete(Customer customer)
        {
            cntx.CustomersTbl.Remove(customer);
        }

        public async Task<Customer> GetCustomerByID(int ID)
        {
            return await cntx.CustomersTbl.FindAsync(ID);
        }

        public async Task Save()
        {
            await cntx.SaveChangesAsync();
        }

        public void Update(Customer customer)
        {
            cntx.CustomersTbl.Update(customer);
        }
    }
}
