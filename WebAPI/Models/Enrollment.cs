using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    class Enrollment
    {
        [JsonPropertyName("ENROLLMENT_ID")]
        public virtual string ENROLLMENT_ID { get; set; }

        [JsonPropertyName("STUDENT_ID")]
        public virtual string STUDENT_ID { get; set; }

        [JsonPropertyName("COURSE_ID")]
        public virtual string COURSE_ID { get; set; }

        [JsonPropertyName("ENROLLMENT_DATE")]
        public virtual string ENROLLMENT_DATE { get; set; }
    }
}
