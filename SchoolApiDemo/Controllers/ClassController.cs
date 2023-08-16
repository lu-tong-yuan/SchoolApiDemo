using Microsoft.AspNetCore.Mvc;
using SchoolApiDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;

        public ClassController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        // GET: api/<ClassController>
        [HttpGet("Class")]
        public IActionResult GetClasses()
        {
            var result = _schoolContext.Class.Select(a => a);

            if (result == null || result.Count() == 0)
            {
                return NotFound("沒有課程名單");
            }

            return Ok(result);
        }
    }
}
