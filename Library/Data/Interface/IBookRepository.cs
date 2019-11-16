using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBook();

        Task<Book> GetBookByID(int ID);

        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);

        Task Save();
    }
}
