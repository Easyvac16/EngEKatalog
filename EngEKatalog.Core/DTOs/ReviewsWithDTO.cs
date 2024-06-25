using EngEKatalog.Core.SomeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngEKatalog.Core.DTOs
{
    public class ReviewsWithDTO
    {
        [JsonPropertyName("reviews")]
        public List<ReviewsDTO> Reviews { get; set; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

        [JsonPropertyName("product_rating")]

        [JsonConverter(typeof(StringToDoubleConverter))]
        public double? Rating { get; set; }

        [JsonPropertyName("product_num_reviews")]
        public int NumReviews { get; set; }

    }
}
