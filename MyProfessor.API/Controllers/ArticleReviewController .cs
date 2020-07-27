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
    public class ArticleReviewController:Controller
    {
        private IArticleReviewService _context;

        public ArticleReviewController(IArticleReviewService context)
        {
            _context = context;
        }

   
        [HttpGet("/articlereviews")]
        public async Task<IActionResult> GetArticleReviews()
        {
            var articles = await _context.GetAllArticleReviews();
            return Ok(articles);
        }


        [HttpGet("/articlereviews/{id}")]
        public async Task<IActionResult> GetArticleReviewById(int id)
        {
            var articles = await _context.GetArticleReviewById(id);
            return Ok(articles);
        }

        //[ValidateAntiForgeryToken]
        //creating article
        public async Task<IActionResult> AddNewArticleReview(ArticleReview articleReview)
        {
            return Ok(await _context.AddArticleReview(articleReview));
        }

        [HttpPost("/articlereviews/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle([Bind("Stars,Review")]ArticleReview articleReview)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddArticleReview(articleReview);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //create a view for adding a new article (writing form)
            return View(articleReview);
        }

        [HttpPost("/articlereviews/{Id}/edit"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateArticle(int Id)
        {
            var articleReview = await _context.GetArticleReviewById(Id);
            return Ok(await _context.EditArticleReview(articleReview));
        }

        [HttpDelete("/articlereviews/{Id}/delete")]
        public async Task<IActionResult> RemoveArticle(int Id)
        {
            var articleReview = await _context.GetArticleReviewById(Id);
            return Ok(await _context.RemoveArticleReview(articleReview));
        }
                

    }
}
