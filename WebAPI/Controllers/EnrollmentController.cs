using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models;
using WebAPI.Persistance;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository enrollmentRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollmentData()
        {
            return Ok(enrollmentRepository.GetAll());
        }

        [HttpGet("{enrollment_id}")]
        public ActionResult<Enrollment> GetEnrollmentById(string enrollment_id)
        {
            var enrollment = enrollmentRepository.Get(enrollment_id);

            if (enrollment == null)
                return NotFound();

            return Ok(enrollment);
        }

        [HttpDelete("{enrollment_id}")]
        public ActionResult DeleteEnrollment(string enrollment_id)
        {
            var enrollment = enrollmentRepository.Get(enrollment_id);

            if (enrollment == null)
                return NotFound();

            enrollmentRepository.Delete(enrollment_id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Enrollment> AddEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("Invalid enrollment data");
            }

            enrollment = enrollmentRepository.Add(enrollment);
            return Ok(enrollment);
        }

        [HttpPut("{enrollment_id}")]
        public ActionResult<Enrollment> UpdateEnrollment(string enrollment_id, Enrollment updatedEnrollment)
        {
            var existingEnrollment = enrollmentRepository.Get(enrollment_id);

            if (existingEnrollment == null)
                return NotFound();

            existingEnrollment.ENROLLMENT_DATE = updatedEnrollment.ENROLLMENT_DATE;
            existingEnrollment.STUDENT_ID = updatedEnrollment.STUDENT_ID;
            existingEnrollment.COURSE_ID = updatedEnrollment.COURSE_ID;

            enrollmentRepository.Update(existingEnrollment);

            return Ok(existingEnrollment);
        }

    }
}
