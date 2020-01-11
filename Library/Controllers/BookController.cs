using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Interface;
using Library.Data.Models;
using Library.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        #region Constructor + Repository

        private readonly IBookRepository repo;
        private readonly IAuthorRepository repoAuthor;
        public BookController(IBookRepository book, IAuthorRepository authorRepository)
        {
            repo = book;
            repoAuthor = authorRepository;
        }
        #endregion

        #region List.............................
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var x = await repo.GetBookWithAuthors();
            return View(x);
        }
        #endregion

        #region Add..............................

        public async Task<IActionResult> Add()
        {
            var BookVM = new BookViewModel
            {
                authors = await repoAuthor.GetAllAuthors()
            };
            return View(BookVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                repo.Add(bookViewModel.book);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            bookViewModel.authors = await repoAuthor.GetAllAuthors();
            return View(bookViewModel);
        }
        #endregion

        #region Edit.............................
        public async Task<IActionResult> Edit(int ID)
        {
            var BookVM = new BookViewModel
            {
                book = await repo.GetBookByID(ID),
                authors = await repoAuthor.GetAllAuthors()
            };
            return View(BookVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repo.Update(book);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        #endregion

        #region Delete...........................
        public async Task<IActionResult> Delete(int ID)
        {
            var c = await repo.GetBookByID(ID);
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int ID)
        {
            if (ModelState.IsValid)
            {
                var c = await repo.GetBookByID(ID);
                repo.Delete(c);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        #endregion

        //#region Details...........................
        //public async Task<IActionResult> Detail(int ID)
        //{
        //    var c = await repo.GetBookByID(ID);
        //    return View(c);
        //}
        //#endregion
    }
}