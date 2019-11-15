using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface ICustomerInterface
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerByID(int ID);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task Save();
    }
}
