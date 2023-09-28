using WebAPI.Models;

namespace WebAPI.Persistance
{
    public interface ICourseProfessorRepository
    {
        CourseProfessor Get(string course_professor_id);
        IEnumerable<CourseProfessor> GetAll();
        CourseProfessor Add(CourseProfessor course_professor);
        void Delete(string course_professor_id);
        bool Update(CourseProfessor course_professor);
    }
}
