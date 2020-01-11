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
    public class CustomerController : Controller
    {

        #region Contrauctor + Repository

        private readonly ICustomerRepository repo;

        public CustomerController(ICustomerRepository customer)
        {
            repo = customer;
        }
        #endregion

        #region List Customer....................
        public async Task<IActionResult> Index()
        {
            var c = await repo.GetAllCustomer();
            return View(c);
        }
        #endregion

        #region Add Customer.....................

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.Add(customer);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        #endregion

        #region Edit.............................
        public async Task<IActionResult> Edit(int ID)
        {
            var c = await repo.GetCustomerByID(ID);
            return View(c);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.Update(customer);
                await repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        #endregion

        #region Delete...........................
        public async Task<IActionResult> Delete(int ID)
        {
            var c = await repo.GetCustomerByID(ID);
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int ID)
        {
            if (ModelState.IsValid)
            {
                var c = await repo.GetCustomerByID(ID);
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
            var c = await repo.GetCustomerByID(ID);
            return View(c);
        }
        #endregion
    }
}