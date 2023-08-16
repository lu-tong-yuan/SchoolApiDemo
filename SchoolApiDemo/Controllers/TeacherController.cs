using Microsoft.AspNetCore.Mvc;
using SchoolApiDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;

        public TeacherController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        // GET: api/<TeacherController>
        [HttpGet("Teacher")]
        public IActionResult GetTeachers()
        {
            var result = _schoolContext.Teacher.Select(a => a);

            if (result == null || result.Count() == 0)
            {
                return NotFound("沒有老師名單");
            }

            return Ok(result);
        }
    }
}
