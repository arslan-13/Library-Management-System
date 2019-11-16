using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Interface;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        #region Contructor + Repository

        private readonly IBookRepository repo;

        public BookController(IBookRepository book)
        {
            repo = book;
        }
        #endregion

        #region List.............................
        public async Task<IActionResult> Index()
        {
            var x = await repo.GetAllBook();
            return View(x);
        }
        #endregion

        #region Add..............................

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Book book)
        {
            if (ModelState.IsValid)
            {
                repo.Add(book);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        #endregion

        #region Edit.............................
        public async Task<IActionResult> Edit(int ID)
        {
            var c = await repo.GetBookByID(ID);
            return View(c);
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

        #region Details...........................
        public async Task<IActionResult> Detail(int ID)
        {
            var c = await repo.GetBookByID(ID);
            return View(c);
        }
        #endregion
    }
}