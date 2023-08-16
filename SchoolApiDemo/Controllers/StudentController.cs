using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SchoolApiDemo.Dtos;
using SchoolApiDemo.Models;
using SchoolApiDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;
        private readonly StudentService _studentService;

        public StudentController(SchoolContext schoolContext, StudentService studentService)
        {
            _schoolContext = schoolContext;
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult GetStudents()
        {
            var result = _studentService.GetStudentList();

            if (result == null || result.Count() == 0)
            {
                return NotFound("沒有學生名單");
            }

            return Ok(result);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var result = _studentService.GetStudent(id);

            if (result == null)
            {
                return NotFound("找不到學生");
            }

            return Ok(result);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult PostStudent([FromBody] StudentPostDto value)
        {
            var insert = _studentService.PostStudent(value);
            
            return CreatedAtAction(nameof(GetStudent),new { id = insert.StudentID }, insert);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, [FromBody] StudentPutDto value)
        {
            if (_studentService.PutStudent(id, value) == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_studentService.DeleteStudent(id) == 0)
            {
                return NotFound("找不到刪除的學生");
            }

            return NoContent();
        }
    }
}
