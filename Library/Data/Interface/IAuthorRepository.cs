using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Interface
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();

        Task<Author> GetAuthorByID(int ID);

        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);

        Task Save();
    }
}
