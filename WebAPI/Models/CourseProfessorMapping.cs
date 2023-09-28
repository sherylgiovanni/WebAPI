using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class CourseProfessorMapping : ClassMap<CourseProfessor>
    {
        public CourseProfessorMapping() {
            Table("CourseProfessor");

            Id(x => x.COURSE_PROFESSOR_ID, "COURSE_PROFESSOR_ID");
            Map(x => x.PROFESSOR_ID);
            Map(x => x.COURSE_ID);
        }
    }
}
