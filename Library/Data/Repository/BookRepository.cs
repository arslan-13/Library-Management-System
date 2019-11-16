using Library.Data.Interface;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext cntx;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            cntx = libraryDbContext;
        }
        public void Add(Book book)
        {
            cntx.BookTbl.Add(book);
        }

        public void Delete(Book book)
        {
            cntx.BookTbl.Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await cntx.BookTbl.ToListAsync();
        }

        public async Task<Book> GetBookByID(int ID)
        {
            return await cntx.BookTbl.FindAsync(ID);
        }

        public async Task Save()
        {
            await cntx.SaveChangesAsync();
        }

        public void Update(Book book)
        {
            cntx.BookTbl.Update(book);
        }

        public async Task<IEnumerable<Book>> GetBookWithAuthors()
        {
            return await cntx.BookTbl.Include(x => x.Author).ToListAsync();
        }

        public IEnumerable<Book> GetAvailableBook()
        {
            return cntx.BookTbl.Include(x => x.Author).Where(x => x.CustID == 0);
        }
    }
}
