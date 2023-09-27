using WebAPI.Models;

namespace WebAPI.Persistance
{
    public interface IStudentRepository
    {
        Student Get(string emplid);
        IEnumerable<Student> GetAll();
        Student Add(Student student);
        void Delete(string emplid);
        bool Update(Student student);
    }
}
