using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models;
using WebAPI.Persistance;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseProfessorController : ControllerBase
    {
        private readonly ICourseProfessorRepository courseProfessorRepository;

        public CourseProfessorController(ICourseProfessorRepository courseProfessorRepository)
        {
            this.courseProfessorRepository = courseProfessorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseProfessor>> GetCourseProfessorData()
        {
            return Ok(courseProfessorRepository.GetAll());
        }

        [HttpGet("{course_professor_id}")]
        public ActionResult<CourseProfessor> GetCourseProfessorById(string course_professor_id)
        {
            var courseProfessor = courseProfessorRepository.Get(course_professor_id);

            if (courseProfessor == null)
                return NotFound();

            return Ok(courseProfessor);
        }

        [HttpDelete("{course_professor_id}")]
        public ActionResult DeleteCourseProfessor(string course_professor_id)
        {
            var courseProfessor = courseProfessorRepository.Get(course_professor_id);

            if (courseProfessor == null)
                return NotFound();

            courseProfessorRepository.Delete(course_professor_id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<CourseProfessor> AddCourseProfessor(CourseProfessor courseProfessor)
        {
            if (courseProfessor == null)
            {
                return BadRequest("Invalid courseProfessor data");
            }

            courseProfessor = courseProfessorRepository.Add(courseProfessor);
            return Ok(courseProfessor);
        }

        [HttpPut("{course_professor_id}")]
        public ActionResult<CourseProfessor> UpdateCourseProfessor(string course_professor_id, CourseProfessor updatedCourseProfessor)
        {
            var existingCourseProfessor = courseProfessorRepository.Get(course_professor_id);

            if (existingCourseProfessor == null)
                return NotFound();

            existingCourseProfessor.PROFESSOR_ID = updatedCourseProfessor.PROFESSOR_ID;
            existingCourseProfessor.COURSE_ID = updatedCourseProfessor.COURSE_ID;

            courseProfessorRepository.Update(existingCourseProfessor);

            return Ok(existingCourseProfessor);
        }

    }
}
