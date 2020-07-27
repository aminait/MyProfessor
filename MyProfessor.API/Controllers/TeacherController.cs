using Microsoft.AspNetCore.Mvc;
using MyProfessor.DataAccess;
using MyProfessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyProfessor.API.Controllers
{
    /// <summary>
    /// This controller belong to teacher entity
    /// </summary>
    [Produces("application/json")]
    public class TeacherController:ControllerBase
    {
/*        private DiscDbContext _context;


        /// <summary>
        /// constructor 
        /// </summary>
        public TeacherController()
        {

        }

        [HttpGet("teachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            return Ok();
        }

        [HttpGet("teachers/{id}")]
        public async Task<IActionResult> SearchTeachers(SystemUsers teacher)
        {
            return Ok();
        }

        public async IActionResult GetTeachers()
        {
            var teachersFromDb = _context.GetAllTeachers();
        }*/
    }
}
