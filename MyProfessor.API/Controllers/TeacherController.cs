using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyProfessor.API.Controllers
{
    /// <summary>
    /// This controller belong to techer entity
    /// </summary>
    [Produces("application/json")]
    public class TeacherController:ControllerBase
    {
        /// <summary>
        /// constructor 
        /// </summary>
        public TeacherController()
        {

        }

        [HttpGet("teachers")]
        public async Task<IActionResult> GetTeachers()
        {
            return Ok();
        }
    }
}
