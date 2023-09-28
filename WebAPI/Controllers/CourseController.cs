using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models;
using WebAPI.Persistance;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourseData()
        {
            return Ok(courseRepository.GetAll());
        }

        [HttpGet("{course_id}")]
        public ActionResult<Course> GetCourseById(string course_id)
        {
            var course = courseRepository.Get(course_id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpDelete("{course_id}")]
        public ActionResult DeleteCourse(string course_id)
        {
            var course = courseRepository.Get(course_id);

            if (course == null)
                return NotFound();

            courseRepository.Delete(course_id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Course> AddCourse(Course course)
        {
            if (course == null)
            {
                return BadRequest("Invalid course data");
            }

            course = courseRepository.Add(course);
            return Ok(course);
        }

        [HttpPut("{course_id}")]
        public ActionResult<Course> UpdateCourse(string course_id, Course updatedCourse)
        {
            var existingCourse = courseRepository.Get(course_id);

            if (existingCourse == null)
                return NotFound();

            existingCourse.CREDITS = updatedCourse.CREDITS;
            existingCourse.COURSE_CODE = updatedCourse.COURSE_CODE;
            existingCourse.COURSE_SECTION = updatedCourse.COURSE_SECTION;
            existingCourse.COURSE_DESC = updatedCourse.COURSE_DESC;
            existingCourse.COURSE_NAME = updatedCourse.COURSE_NAME;

            courseRepository.Update(existingCourse);

            return Ok(existingCourse);
        }

    }
}
