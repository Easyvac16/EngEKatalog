using EngEKatalog.Core.SomeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngEKatalog.Core.DTOs
{
	public class OffersWithDTO
	{
		[JsonPropertyName("offers")]
		public List<OffersDTO> Offers { get; set; }

		[JsonPropertyName("product_rating")]

        [JsonConverter(typeof(StringToDoubleConverter))]
        public double? ProductRating { get; set; }

		[JsonPropertyName("product_num_reviews")]
		public int NumberReviews { get; set; }
	}
}
