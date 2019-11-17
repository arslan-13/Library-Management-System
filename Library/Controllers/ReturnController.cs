using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class ReturnController : Controller
    {
        private readonly ICustomerRepository repoCust;
        private readonly IBookRepository repoBook;

        public ReturnController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            repoCust = customerRepository;
            repoBook = bookRepository;
        }
        #region Return List......................
        public IActionResult Index()
        {
            var LendedBook = repoBook.GetBookWithAuthorAndCustomer();
            if (LendedBook == null || LendedBook.Count() == 0)
            {
                return View("Empty");
            }
            return View(LendedBook);
        }
        #endregion

        #region Return Book......................
        public async Task<IActionResult> Return(int ID)
        {
            var book = await repoBook.GetBookByID(ID);
            book.Customer = null;
            book.CustomerID = 0;
            repoBook.Update(book);
            await repoBook.Save();

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}