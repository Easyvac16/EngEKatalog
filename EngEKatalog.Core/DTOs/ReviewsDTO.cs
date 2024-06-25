using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngEKatalog.Core.DTOs
{
    public class ReviewsDTO
    {
        [JsonPropertyName("review_id")]
        public string ReviewId { get; set; }

        [JsonPropertyName("review_title")]
        public string ReviewTitle { get; set; }

        [JsonPropertyName("review_author")]
        public string ReviewAuthor { get; set; }

        [JsonPropertyName("review_source")]
        public string ReviewSource { get; set; }

        [JsonPropertyName("review_source_url")]
        public string ReviewSourceUrl { get; set; }

        [JsonPropertyName("review_text")]
        public string ReviewText { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("review_datetime_utc")]
        public DateTime ReviewDatetimeUtc { get; set; }

        [JsonPropertyName("review_language")]
        public string ReviewLanguage { get; set; }

        [JsonPropertyName("photos")]
        public List<string> Photos { get; set; }
    }
}
