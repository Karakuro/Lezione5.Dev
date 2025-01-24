using Lezione5.Dev.DTO;
using Lezione5.Dev.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lezione5.Dev.Controllers
{
    //   https://localhost:7012/api/Student
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Examples
        //// GET: https://localhost:7012/api/Student
        //[HttpGet]
        //public string Get()
        //{
        //    return "Hello from StudentController";
        //}

        //// GET: https://localhost:7012/api/Student/5
        //[HttpGet]
        //[Route("{id}")]
        //public string Get(int id)
        //{
        //    return "Hello from StudentController with id: " + id;
        //}

        //// GET: https://localhost:7012/5
        //[HttpGet]
        //[Route("/{id}")]
        //public string GetBasic(int id)
        //{
        //    return "Hello from StudentController with id: " + id;
        //}
        #endregion

        private static List<Student> students = new List<Student>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                Student? s = students.SingleOrDefault(s => s.Id == id);
                return s != null ? Ok(s) : BadRequest();
            }
            catch (ArgumentNullException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Id non popolato");
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dati sporchi. Contattare l'amministratore di sistema ASAP");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errore generico del server. Si prega di riprovare più tardi. In caso di persistenza dell'errore, bestemmiare agli amministratori di sistema.");
            }
        }

        [HttpPost]
        public IActionResult Create(StudentDTO student)
        {
            Student newStudent = new Student
            {
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                FiscalCode = student.FiscalCode
            };
            students.Add(newStudent);
            return Created("", newStudent);
        }

    }
}
