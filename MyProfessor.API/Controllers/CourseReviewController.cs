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
    public class CourseReviewController : Controller
    {
        private ICourseReviewService _context;

        public CourseReviewController(ICourseReviewService context)
        {
            _context = context;
        }

        [HttpGet("/course-reviews")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.GetAllCourseReviews();
            return Ok(courses);
        }


        [HttpGet("/course-reviews/{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var courses = await _context.GetCourseReviewById(id);
            return Ok(courses);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewCourseReview(CourseReview courseReview)
        {
            return Ok(await _context.AddCourseReview(courseReview));
        }

        [HttpPost("/course-reviews/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourseReview([Bind("Stars, Review")]CourseReview courseReview)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddCourseReview(courseReview);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //create a view for adding a new article (writing form)
            return View(courseReview);
        }

        [HttpPost("/coursereviews/{Id}/edit"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCourse(int Id)
        {
            var courseReview = await _context.GetCourseReviewById(Id);
            return Ok(await _context.RemoveCourseReview(courseReview));
        }

        [HttpDelete("/coursereviews/{Id}/delete")]
        public async Task<IActionResult> RemoveCourseReview(int Id)
        {
            var courseReview = await _context.GetCourseReviewById(Id);
            return Ok(await _context.RemoveCourseReview(courseReview));
        }

        

       /* // GET: Courses
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
        }*/

       /* [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<CourseDto>> GetCourses(string category)
        {

        }*/
    }
}
