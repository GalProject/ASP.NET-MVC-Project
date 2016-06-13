using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication2_2.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using System.Net;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2_2.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlogController
        public IActionResult Index()
        {
           List<object> a = new List<object>();
           a.Add(_context.Posts.ToList());
           a.Add(_context.Comments.ToList());
            return View(a);
        }

        //Search1
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            //EXAMPLE TO LINQ
            var posts = from m in _context.Posts
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                //WHERE,GROUPBY,CONTAINS AND MORE..
                posts = posts.Where(s => s.PostTitle.Contains(searchString));
            }
            List<object> a = new List<object>();
            a.Add(await posts.ToListAsync());
            a.Add(_context.Comments.ToList());
            return View(a);
        }

        //Search2
        [HttpPost]
        public async Task<IActionResult> IndexComment(string searchString)
        {
            //EXAMPLE TO LINQ
            var comments = from m in _context.Comments
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                //WHERE,GROUPBY,CONTAINS AND MORE..
                comments = comments.Where(s => s.CommentWriter.Contains(searchString));
            }
            List<object> a = new List<object>();
            a.Add(_context.Posts.ToList());
            a.Add(await comments.ToListAsync());
            return View("Index",a);
        }

        // POST: Blog/CreateComment
        [HttpPost]
        public IActionResult CreateComment(string name, string title, string website, string comment, int postId)
        {
            //Added New Comment
            Comment a = new Comment();
            a.CommentWriter = name;
            a.CommentTitle = title;
            a.CommentWriterURL = website;
            a.CommentContent = comment;
            a.PostID = postId;
            _context.Comments.Add(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Blog:About us
        public IActionResult About()
        {
            return View(_context.Stores.ToList());
        }

        //Get All Locations From Database
        public JsonResult GetLocations()
        {
            List<Store> listOfStores = _context.Stores.ToList();
            return Json(listOfStores);
        }

    }
}
