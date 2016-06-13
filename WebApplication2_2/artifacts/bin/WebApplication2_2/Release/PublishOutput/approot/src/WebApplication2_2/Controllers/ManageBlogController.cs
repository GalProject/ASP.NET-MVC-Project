using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication2_2.Models;
using System.Net;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2_2.Controllers
{
    public class ManageBlogController : Controller
    {
        private ApplicationDbContext _context;
        public ManageBlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<object> a = new List<object>();
            a.Add(_context.Posts.ToList());
            a.Add(_context.Games.ToList());
            a.Add(_context.HallOfFame.ToList());
            a.Add(_context.Stores.ToList());
            return View(a);
        }

        /**/
        //ManageBlog/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Post post = _context.Posts.Single(m => m.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }


        //ManageBlog/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: ManageBlog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                //Add Current date
                DateTime now = DateTime.Now;
                post.PostDate = now;
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }


        // GET: ManageBlog/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
             Post post = _context.Posts.Single(m => m.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: ManageBlog/Edit/5
        //ADDED Bind
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Update(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        

        // GET: ManageBlog/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Post post = _context.Posts.Single(m => m.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // POST: ManageBlog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Post post = _context.Posts.Single(m => m.ID == id);
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




        // GET: ManageBlog/ManageComments/5
        public IActionResult ManageComments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
                // return HttpNotFound();
            }

            var comments = _context.Comments.Where(m => m.PostID == id).ToList();
            if (comments == null)
            {
                return HttpNotFound();
            }


            return View(comments);
        }
        

        // GET: ManageBlog/Delete/5
        [ActionName("DeleteComment")]
        public IActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comment comment = _context.Comments.Single(m => m.ID == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // POST: ManageBlog/Delete/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCommentConfirmed(int id)
        {
            Comment comment = _context.Comments.Single(m => m.ID == id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
