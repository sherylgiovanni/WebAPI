using WebAPI.Models;

namespace WebAPI.Persistance
{
    public interface IProfessorRepository
    {
        Professor Get(string emplid);
        IEnumerable<Professor> GetAll();
        Professor Add(Professor professor);
        void Delete(string emplid);
        bool Update(Professor professor);
    }
}
