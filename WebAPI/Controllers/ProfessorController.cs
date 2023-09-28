using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models;
using WebAPI.Persistance;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            this.professorRepository = professorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> GetProfessorData()
        {
            return Ok(professorRepository.GetAll());
        }

        [HttpGet("{emplid}")]
        public ActionResult<Professor> GetProfessorById(string emplid)
        {
            var professor = professorRepository.Get(emplid);

            if (professor == null)
                return NotFound();

            return Ok(professor);
        }

        [HttpDelete("{emplid}")]
        public ActionResult DeleteProfessor(string emplid)
        {
            var professor = professorRepository.Get(emplid);

            if (professor == null)
                return NotFound();

            professorRepository.Delete(emplid);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Professor> AddProfessor(Professor professor)
        {
            if (professor == null)
            {
                return BadRequest("Invalid professor data");
            }

            professor = professorRepository.Add(professor);
            return Ok(professor);
        }

        [HttpPut("{emplid}")]
        public ActionResult<Professor> UpdateProfessor(string emplid, Professor updatedProfessor)
        {
            var existingProfessor = professorRepository.Get(emplid);

            if (existingProfessor == null)
                return NotFound();

            existingProfessor.FIRST_NAME = updatedProfessor.FIRST_NAME;
            existingProfessor.LAST_NAME = updatedProfessor.LAST_NAME;
            existingProfessor.EMAIL_ADDRESS = updatedProfessor.EMAIL_ADDRESS;

            professorRepository.Update(existingProfessor);

            return Ok(existingProfessor);
        }

    }
}
