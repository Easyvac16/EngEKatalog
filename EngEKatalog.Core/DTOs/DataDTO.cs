using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngEKatalog.Core.DTOs
{
    public class DataDTO
    {
        [JsonPropertyName("product_id")]
        public string product_id { get; set; }

        [JsonPropertyName("product")]
        public ProductDTO Product { get; set; }

        [JsonPropertyName("reviews_sample")]
        public List<ReviewsDTO> ReviewsSample { get; set; }

        [JsonPropertyName("reviews_per_rating")]
        public Dictionary<int, int> ReviewsPerRating { get; set; }

        [JsonPropertyName("reviews_insights")]
        public Dictionary<string, Dictionary<string, int>> ReviewsInsights { get; set; }

        [JsonPropertyName("product_highlights")]
        public List<string> ProductHighlights { get; set; }

        [JsonPropertyName("product_details")]
        public Dictionary<string, string> ProductDetails { get; set; }

        [JsonPropertyName("product_specs")]
        public Dictionary<string, string> ProductSpecs { get; set; }

        [JsonPropertyName("product_attributes")]
        public Dictionary<string, string> ProductAttributes { get; set; }
    }
}
