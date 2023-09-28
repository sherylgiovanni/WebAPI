using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Course
    {
        [JsonPropertyName("COURSE_ID")]
        public virtual string COURSE_ID { get; set; }

        [JsonPropertyName("COURSE_NAME")]
        public virtual string COURSE_NAME { get; set; }

        [JsonPropertyName("COURSE_CODE")]
        public virtual string COURSE_CODE { get; set; }

        [JsonPropertyName("COURSE_DESC")]
        public virtual string COURSE_DESC { get; set; }

        [JsonPropertyName("COURSE_SECTION")]
        public virtual string COURSE_SECTION { get; set; }

        [JsonPropertyName("CREDITS")]
        public virtual int CREDITS { get; set; }
    }
}
