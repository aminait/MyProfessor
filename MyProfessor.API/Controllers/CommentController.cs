using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProfessor.Models;
using MyProfessor.Services.Main;

namespace MyProfessor.API.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService _context;

        public CommentController(ICommentService context)
        {
            _context = context;
        }

        [HttpGet("/comments")]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _context.GetAllComments();
            return Ok(comments);
        }


        [HttpGet("/comments/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _context.GetCommentById(id);
            return Ok(comment);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //creating new comment
        //this is useless
        public async Task<IActionResult> AddNewComment(Comment comment)
        {
            return Ok(await _context.AddComment(comment));
        }

        [HttpPost("/comments/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse([Bind("CommentData")]Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddComment(comment);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //create a view for adding a new article (writing form)
            return View(comment);
        }

        [HttpPost("/comments/{Id}/edit"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateComment(int Id)
        {
            var comment = await _context.GetCommentById(Id);
            return Ok(await _context.RemoveComment(comment));
        }

        [HttpDelete("/comments/{Id}/delete")]
        public async Task<IActionResult> RemoveComment(int Id)
        {
            var comment = await _context.GetCommentById(Id);
            return Ok(await _context.RemoveComment(comment));
        }

        


/*
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Courses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       *//* [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<CourseDto>> GetCourses(string category)
        {

        }*/
    }
}