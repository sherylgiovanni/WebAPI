using WebAPI.Models;

namespace WebAPI.Persistance
{
    public interface ICourseRepository
    {
        Course Get(string course_id);
        IEnumerable<Course> GetAll();
        Course Add(Course course);
        void Delete(string course_id);
        bool Update(Course course);
    }
}
