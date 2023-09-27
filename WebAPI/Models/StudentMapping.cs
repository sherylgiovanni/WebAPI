using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class StudentMapping : ClassMap<Student>
    {
        public StudentMapping() {
            Table("Student");

            Id(x => x.EMPLID, "EMPLID");
            Map(x => x.FIRST_NAME);
            Map(x => x.LAST_NAME);
            Map(x => x.EMAIL_ADDRESS);
        }
    }
}
