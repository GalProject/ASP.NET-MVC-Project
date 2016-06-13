using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication2_2.Models;
using System.Collections.Generic;

namespace WebApplication2_2.Controllers
{
    public class StoresController : Controller
    {
        private ApplicationDbContext _context;

        public StoresController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Stores
        public IActionResult Index()
        {
            return View(_context.Stores.ToList());
        }
        // GET: Stores/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Store store = _context.Stores.Single(m => m.ID == id);
            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                _context.Stores.Add(store);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }


        // GET: Stores/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Store store = _context.Stores.Single(m => m.ID == id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                _context.Update(store);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Store store = _context.Stores.Single(m => m.ID == id);
            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Store store = _context.Stores.Single(m => m.ID == id);
            _context.Stores.Remove(store);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
