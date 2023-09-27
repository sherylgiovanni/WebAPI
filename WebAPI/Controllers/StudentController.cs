using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models;
using WebAPI.Persistance;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudentData()
        {
            return Ok(studentRepository.GetAll());
        }

        [HttpGet("{emplid}")]
        public ActionResult<Student> GetStudentById(string emplid)
        {
            var student = studentRepository.Get(emplid);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpDelete("{emplid}")]
        public ActionResult DeleteStudent(string emplid)
        {
            var student = studentRepository.Get(emplid);

            if (student == null)
                return NotFound();

            studentRepository.Delete(emplid);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid student data");
            }

            student = studentRepository.Add(student);
            return Ok(student);
        }

        [HttpPut("{emplid}")]
        public ActionResult<Student> UpdateStudent(string emplid, Student updatedStudent)
        {
            var existingStudent = studentRepository.Get(emplid);

            if (existingStudent == null)
                return NotFound();

            existingStudent.FIRST_NAME = updatedStudent.FIRST_NAME;
            existingStudent.LAST_NAME = updatedStudent.LAST_NAME;
            existingStudent.EMAIL_ADDRESS = updatedStudent.EMAIL_ADDRESS;

            studentRepository.Update(existingStudent);

            return Ok(existingStudent);
        }

    }
}
