using JRO.Blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JRO.Blog.ViewModels
{
    public class PostFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        [Display(Name = "Author")]
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public string ViewTitle
        {
            get
            {
                if (Id == 0)
                {
                    return "New post";
                }
                else
                {
                    return "Edit post";
                }
            }
        }

        public IEnumerable<ApplicationUser> Authors { get; set; }

        public PostFormViewModel()
        {
            Id = 0;
        }

        public PostFormViewModel(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Body = post.Body;
            AuthorId = post.AuthorId;
            Author = post.Author;
        }
    }
}