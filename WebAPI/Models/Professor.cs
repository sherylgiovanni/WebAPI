using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    class Professor
    {
        [JsonPropertyName("EMPLID")]
        public virtual string EMPLID { get; set; }

        [JsonPropertyName("FIRST_NAME")]
        public virtual string FIRST_NAME { get; set; }

        [JsonPropertyName("LAST_NAME")]
        public virtual string LAST_NAME { get; set; }

        [JsonPropertyName("EMAIL_ADDRESS")]
        public virtual string EMAIL_ADDRESS { get; set; }
    }
}
