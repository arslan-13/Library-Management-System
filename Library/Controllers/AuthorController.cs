using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Interface;
using Library.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        #region Contructor + Repository

        private readonly IAuthorRepository repo;

        public AuthorController(IAuthorRepository author)
        {
            repo = author;
        }
        #endregion

        #region List.............................
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var x = await repo.GetAllAuthors();
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
        public async Task<IActionResult> Add(Author author)
        {
            if (ModelState.IsValid)
            {
                repo.Add(author);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        #endregion

        #region Edit.............................
        public async Task<IActionResult> Edit(int ID)
        {
            var c = await repo.GetAuthorByID(ID);
            return View(c);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                repo.Update(author);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        #endregion

        #region Delete...........................
        public async Task<IActionResult> Delete(int ID)
        {
            var c = await repo.GetAuthorByID(ID);
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int ID)
        {
            if (ModelState.IsValid)
            {
                var c = await repo.GetAuthorByID(ID);
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
            var c = await repo.GetAuthorByID(ID);
            return View(c);
        }
        #endregion
    }
}