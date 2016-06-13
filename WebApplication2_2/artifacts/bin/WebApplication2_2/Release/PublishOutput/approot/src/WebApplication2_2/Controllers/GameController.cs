using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication2_2.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2_2.Controllers
{
    public class GameController : Controller
    {

        private ApplicationDbContext _context;

        public IQueryable<Game> NULL { get; private set; }

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public IActionResult Index()
        {
            return View(_context.Games.ToList());
        }


        //Search
        [HttpPost]
        public IActionResult Index3(string genre, string avl, int price)
        {

            var games = from l in _context.Games
                    where l.GameGenre.Equals(genre) && l.GameAvailability.Equals(avl) && l.GamePrice >= price
                    select l; 


            if (games == NULL){
                return View(_context.Games.ToList());
            }

            else{
                return View("Index", games.ToList());
            }
        }


        public IActionResult Details(int? id)
        {
            List<object> a = new List<object>();
           
            if (id == null)
            {
                return HttpNotFound();
            }
            Game game = _context.Games.Single(m => m.ID == id);
            a.Add(game);
            a.Add(_context.Posts.ToList());
            a.Add(_context.Games.ToList());

            if (game == null)
            {
                return HttpNotFound();
            }

            return View(a);
        }


        public IActionResult Create()
        {
            return View();
        }


        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                //Add Current date
                DateTime now = DateTime.Now;
                game.GameDate = now;
                _context.Games.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Game/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Game game = _context.Games.Single(m => m.ID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Game game = _context.Games.Single(m => m.ID == id);
            _context.Games.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Game/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Game game = _context.Games.Single(m => m.ID == id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/5
        //ADDED Bind
        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                //Post pst = new Post();
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

    }
}
