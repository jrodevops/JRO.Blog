using JRO.Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JRO.Blog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            IEnumerable<Post> posts = _context.Posts.Include(a => a.Author).OrderByDescending(p=>p.DateCreated).Take(3);
            return View(posts);
        }
    }
}