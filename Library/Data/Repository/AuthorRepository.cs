using Library.Data.Interface;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext cntx;

        public AuthorRepository(LibraryDbContext libraryDbcntx)
        {
            cntx = libraryDbcntx;
        }
        public void Add(Author author)
        {
            cntx.AuthorTbl.Add(author);
        }

        public void Delete(Author author)
        {
            cntx.AuthorTbl.Remove(author);
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await cntx.AuthorTbl.ToListAsync();
        }

        public async Task<Author> GetAuthorByID(int ID)
        {
            return await cntx.AuthorTbl.FindAsync(ID);
        }

        public async Task Save()
        {
            await cntx.SaveChangesAsync();
        }

        public void Update(Author author)
        {
            cntx.Update(author);
        }
    }
}
