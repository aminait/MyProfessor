using Microsoft.AspNetCore.Mvc;
using MyProfessor.Models;
using MyProfessor.Services.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace MyProfessor.API.Controllers
{
    [Produces("application/json")]
    public class ArticleController:Controller
    {
        private IArticleService _context;

        public ArticleController(IArticleService context)
        {
            _context = context;
        }

        [HttpGet("/index")]
        public async Task<IActionResult> Index(string courseName = null, string searchString = null)
        {
            var articles = await _context.GetAllArticles();

            //Use LINQ to get list of course names
           /* IQueryable<string> courseQuery = from c in _context.Course
                                             orderby c.Name
                                             select c.Name;

            var courses = from c in _context.Course
                          select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.Name.Contains(searchString));
            }
            //i think this is used like a drop down, to match everything
            if (!string.IsNullOrEmpty(courseName))
            {
                courses = courses.Where(x=>x.Name==courseName)
            }*/

           
            /*var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);*/


            return View(articles);
        }
        //controller action referred to by actionlink in index of article view
        /* public ActionResult Browse(string category)
         {
             var categoryModel = storeDB.Categories.Include("Items")
                 .Single(c => c.Name == category);
             return View(categoryModel);
         }*/

        //search you send the id of the professor then return the view of his reviews



        [HttpGet("/articles")]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _context.GetAllArticles();
            return Ok(articles);
        }


        [HttpGet("/articles/{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var articles = await _context.GetArticleById(id);
            return Ok(articles);
        }

        //[ValidateAntiForgeryToken]
        //creating article
        public async Task<IActionResult> AddNewArticle(Article article)
        {
            return Ok(await _context.AddArticle(article));
        }

        [HttpPost("/articles/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle([Bind("Name,ItemArtUrl,ArticleContent")]Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddArticle(article);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //create a view for adding a new article (writing form)
            return View(article);
        }

        [HttpPost("/articles/{articleId}/edit"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateArticle(int articleId)
        {
            var article = await _context.GetArticleById(articleId);
            return Ok(await _context.UpdateArticle(article));
        }

        [HttpDelete("/articles/{articleId}/delete")]
        public async Task<IActionResult> RemoveArticle(int articleId)
        {
            var article = await _context.GetArticleById(articleId);
            return Ok(await _context.RemoveArticle(article));
        }

        


        /*[HttpPost]
        public IActionResult Search(string term)
        {
            return Redirect($"/blog?term={term}");
        }*/

        /*[HttpPost("upload/{uploadType}")]
        [Authorize]
        public async Task<ActionResult> Upload(IFormFile file, UploadType uploadType, int postId = 0)
        {
            var path = string.Format("{0}/{1}", DateTime.Now.Year, DateTime.Now.Month);
            var asset = await StorageService.UploadFormFile(file, Url.Content("~/"), path);

            if (uploadType == UploadType.AppLogo)
            {
                var logo = DataService.CustomFields.Single(f => f.AuthorId == 0 && f.Name == Constants.BlogLogo);
                if (logo == null)
                    DataService.CustomFields.Add(new CustomField { AuthorId = 0, Name = Constants.BlogLogo, Content = asset.Url });
                else
                    logo.Content = asset.Url;
                DataService.Complete();
            }
            if (uploadType == UploadType.AppCover)
            {
                var cover = DataService.CustomFields.Single(f => f.AuthorId == 0 && f.Name == Constants.BlogCover);
                if (cover == null)
                    DataService.CustomFields.Add(new CustomField { AuthorId = 0, Name = Constants.BlogCover, Content = asset.Url });
                else
                    cover.Content = asset.Url;
                DataService.Complete();
            }
            if (uploadType == UploadType.PostCover)
            {
                await DataService.BlogPosts.SaveCover(postId, asset.Url);
                DataService.Complete();
            }
            if (uploadType == UploadType.Avatar)
            {
                var user = DataService.Authors.Single(a => a.AppUserName == User.Identity.Name);
                user.Avatar = asset.Url;
                DataService.Complete();
            }

            return Json(new { asset.Url });
        }*/

    }
}
