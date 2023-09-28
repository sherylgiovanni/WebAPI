using WebAPI.Models;

namespace WebAPI.Persistance
{
    public interface IEnrollmentRepository
    {
        Enrollment Get(string enrollment_id);
        IEnumerable<Enrollment> GetAll();
        Enrollment Add(Enrollment enrollment);
        void Delete(string enrollment_id);
        bool Update(Enrollment enrollment);
    }
}
