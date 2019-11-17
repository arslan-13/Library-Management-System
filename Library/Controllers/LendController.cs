using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Interface;
using Library.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LendController : Controller
    {
        private readonly ICustomerRepository repoCust;
        private readonly IBookRepository repoBook;

        public LendController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            repoCust = customerRepository;
            repoBook = bookRepository;
        }

        #region List Available Books
        public IActionResult Index()
        {
            var AvailableBooks = repoBook.GetAvailableBook();
            return View(AvailableBooks);
        }
        #endregion

        #region Lend.............................
        public async Task<IActionResult> Lend(int ID)
        {
            var avabook = new LendBookViewModel
            {
                book = await repoBook.GetBookByID(ID),
                customers = await repoCust.GetAllCustomer()
            };
            return View(avabook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Lend(LendBookViewModel lendBookViewModel)
        {
            var book = await repoBook.GetBookByID(lendBookViewModel.book.ID);
            var customer = await repoCust.GetCustomerByID((int)lendBookViewModel.book.CustomerID);
            //book.CustID = customer.ID;
            book.Customer = customer;

            repoBook.Update(book);
            await repoBook.Save();
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}