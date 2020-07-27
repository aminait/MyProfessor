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
    public class CourseController : Controller
    {
        private ICourseService _context;

        public CourseController(ICourseService context)
        {
            _context = context;
        }

        [HttpGet("/courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.GetAllCourses();
            return Ok(courses);
        }


        [HttpGet("/courses/{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var courses = await _context.GetCourseById(id);
            return Ok(courses);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //creating course
        public async Task<IActionResult> AddNewCourse(Course course)
        {
            return Ok(await _context.AddCourse(course));
        }

        [HttpPost("/courses/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse([Bind("Stars, Review")]Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddCourse(course);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //create a view for adding a new article (writing form)
            return View(course);
        }

        [HttpPost("/courses/{Id}/edit"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCourse(int Id)
        {
            var course = await _context.GetCourseById(Id);
            return Ok(await _context.RemoveCourse(course));
        }

        [HttpDelete("/courses/{Id}/delete")]
        public async Task<IActionResult> RemoveCourse(int Id)
        {
            var course = await _context.GetCourseById(Id);
            return Ok(await _context.RemoveCourse(course));
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