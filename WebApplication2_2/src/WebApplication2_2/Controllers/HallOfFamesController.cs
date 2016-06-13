using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication2_2.Models;
using System.Threading.Tasks;
using System;

namespace WebApplication2_2.Controllers
{
    public class HallOfFamesController : Controller
    {
        private ApplicationDbContext _context;

        public HallOfFamesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: HallOfFame
        public IActionResult Index()
        {
            return View(_context.HallOfFame.ToList());
        }

        // GET: HallOfFames/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            HallOfFame HallOfFame = _context.HallOfFame.Single(m => m.ID == id);
            if (HallOfFame == null)
            {
                return HttpNotFound();
            }

            return View(HallOfFame);
        }
        //Search2
        [HttpPost]
        public IActionResult Index2(string sex,string Name, int year)
        {

           var members = from l in _context.HallOfFame
                         where l.Gender.Equals(sex) && l.Name.Equals(Name) && l.NumOfYearsInClub >= year
                      select l;
            
            if (members == null)
{
                return View(_context.HallOfFame.ToList());
            }
            else{
                return View("Index", members.ToList());
            }
        }



        // GET: HallOfFame/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: HallOfFame/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HallOfFame HallOfFame)
        {
            if (ModelState.IsValid)
            {
                _context.HallOfFame.Add(HallOfFame);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(HallOfFame);
        }

        // GET: HallOfFame/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            HallOfFame HallOfFame = _context.HallOfFame.Single(m => m.ID == id);
            if (HallOfFame == null)
            {
                return HttpNotFound();
            }
            return View(HallOfFame);
        }

        // POST: HallOfFame/Edit/5
        //ADDED Bind
        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public IActionResult Edit(HallOfFame HallOfFame)
        {
            if (ModelState.IsValid)
            {
                _context.Update(HallOfFame);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(HallOfFame);
        }

        // GET: HallOfFame/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            HallOfFame HallOfFame = _context.HallOfFame.Single(m => m.ID == id);
            if (HallOfFame == null)
            {
                return HttpNotFound();
            }

            return View(HallOfFame);
        }

        // POST: HallOfFame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            HallOfFame HallOfFame = _context.HallOfFame.Single(m => m.ID == id);
            _context.HallOfFame.Remove(HallOfFame);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
