using JRO.Blog.Models;
using JRO.Blog.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JRO.Blog.Controllers
{
    public class PostsController : Controller
    {
        ApplicationDbContext _context { get; set; }
        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Posts
        public ActionResult Index()
        {
            IEnumerable<Post> posts = _context.Posts.Include(p => p.Author).ToList();
            return View(posts);
        }

        public ActionResult Details(int id)
        {
            Post post = _context.Posts.Include(p => p.Author).SingleOrDefault(p=>p.Id == id);
            if(post == null)
            {   
                return HttpNotFound("Post not found");
            }

            return View(post);
        }

        public ActionResult New()
        {
            string userId = User.Identity.GetUserId();
            PostFormViewModel viewModel = new PostFormViewModel
            {
                Authors = _context.Users.ToList()
            };

            return View("PostFormView", viewModel);
        }

        public ActionResult Edit(int id)
        {
            Post post = _context.Posts.Find(id);
            if(post == null)
            {
                return HttpNotFound("Post not found");
            }

            PostFormViewModel viewModel = new PostFormViewModel(post)
            {
                Authors = _context.Users.ToList()
            };

            return View("PostFormView", viewModel);
        }

        public ActionResult Delete(int id)
        {
            Post post = _context.Posts.Find(id);
            if(post == null)
            {
                return HttpNotFound("Post not found");
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Save(Post post)
        {
            if(!ModelState.IsValid)
            {
                PostFormViewModel viewModel = new PostFormViewModel
                {
                    Authors = _context.Users.ToList()
                };
            }

            if(post.Id == 0)
            {
                post.DateCreated = DateTime.Now;
                _context.Posts.Add(post);
            }
            else
            {
                Post postInDb = _context.Posts.Find(post.Id);
                if(postInDb == null)
                {
                    return HttpNotFound("Post not found");
                }

                postInDb.Title = post.Title;
                postInDb.Body = post.Body;
                postInDb.AuthorId = post.AuthorId;
                postInDb.DateUpdated = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}