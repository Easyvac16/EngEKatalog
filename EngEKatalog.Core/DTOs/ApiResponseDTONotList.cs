using System.Text.Json.Serialization;

namespace EngEKatalog.Core.DTOs
{
    public class ApiResponseDTONotList
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName ("request_id")]
        public string? RequestId { get; set; }

        [JsonPropertyName("data")]
        public DataDTO Data { get; set; }

    }
}
