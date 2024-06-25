using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngEKatalog.Core.DTOs
{
    public class ReviewsResponseDTO
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("request_id")]
        public string? RequestId { get; set; }

        [JsonPropertyName("data")]
        public ReviewsWithDTO Data { get; set; }
    }
}
