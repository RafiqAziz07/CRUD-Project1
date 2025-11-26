using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static List<Models.Student> students = new List<Models.Student>
        {
            new Models.Student { Id = 1, Name = "Alice", Age = 20 },
            new Models.Student { Id = 2, Name = "Bob", Age = 22 },
            new Models.Student { Id = 3, Name = "Charlie", Age = 23 }
        };
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);

        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Add(string Name, int Age)
        {
            var student = new Models.Student { Id = students.Count + 1, Name = Name, Age = Age };
            students.Add(student);
            return Ok(student);



        }
        [HttpDelete("{id}")]
        public IActionResult Delate(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            
            students.Remove(student);
            return Ok(student);
        }

    }
}

