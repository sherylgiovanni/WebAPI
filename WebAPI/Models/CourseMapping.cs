using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class CourseMapping : ClassMap<Course>
    {
        public CourseMapping() {
            Table("Course");

            Id(x => x.COURSE_ID, "COURSE_ID");
            Map(x => x.COURSE_CODE);
            Map(x => x.COURSE_NAME);
            Map(x => x.COURSE_SECTION);
            Map(x => x.COURSE_DESC);
            Map(x => x.CREDITS);
        }
    }
}
