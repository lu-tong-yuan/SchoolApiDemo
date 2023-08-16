using Microsoft.AspNetCore.Mvc;
using SchoolApiDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;

        public ScoreController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        // GET: api/<ScoreController>
        [HttpGet("Score")]
        public IActionResult GetScores()
        {
            var result = _schoolContext.Score.Select(a => a);

            if (result == null || result.Count() == 0)
            {
                return NotFound("沒有分數名單");
            }

            return Ok(result);
        }
    }
}
