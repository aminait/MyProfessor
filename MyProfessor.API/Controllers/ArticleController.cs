using Microsoft.AspNetCore.Mvc;
using MyProfessor.Services.Main;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var articles = await _context.GetAllArticles();
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



        [HttpGet("articles")]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _context.GetAllArticles();
            return Ok(articles);
        }


        [HttpGet("articles/{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var articles = await _context.GetArticleById(id);
            return Ok(articles);
        }



    }
}
