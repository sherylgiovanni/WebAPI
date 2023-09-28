using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class ProfessorMapping : ClassMap<Professor>
    {
        public ProfessorMapping() {
            Table("Professor");

            Id(x => x.EMPLID, "EMPLID");
            Map(x => x.FIRST_NAME);
            Map(x => x.LAST_NAME);
            Map(x => x.EMAIL_ADDRESS);
        }
    }
}
