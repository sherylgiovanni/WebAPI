using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class EnrollmentMapping : ClassMap<Enrollment>
    {
        public EnrollmentMapping() {
            Table("Enrollment");

            Id(x => x.ENROLLMENT_ID, "ENROLLMENT_ID");
            Map(x => x.ENROLLMENT_DATE);
            Map(x => x.STUDENT_ID);
            Map(x => x.COURSE_ID);
        }
    }
}
