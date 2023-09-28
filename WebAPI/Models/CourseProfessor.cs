using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class CourseProfessor
    {
        [JsonPropertyName("COURSE_PROFESSOR_ID")]
        public virtual string COURSE_PROFESSOR_ID { get; set; }

        [JsonPropertyName("COURSE_ID")]
        public virtual string COURSE_ID { get; set; }

        [JsonPropertyName("PROFESSOR_ID")]
        public virtual string PROFESSOR_ID { get; set; }
    }
}
