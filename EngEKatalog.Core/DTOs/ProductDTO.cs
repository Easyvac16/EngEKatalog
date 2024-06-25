
using EngEKatalog.Core.SomeClasses;
using System.Text.Json.Serialization;

namespace EngEKatalog.Core.DTOs
{
    public class ProductDTO
    {
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("product_title")]
        public string ProductTitle { get; set; }

        [JsonPropertyName("product_description")]
        public string ProductDescription { get; set; }

        [JsonPropertyName("product_photos")]
        public List<string> ProductPhotos { get; set; }

        [JsonPropertyName("product_attributes")]
        public Dictionary<string, string> ProductAttributes { get; set; }

        [JsonPropertyName("product_rating")]
        [JsonConverter(typeof(StringToDoubleConverter))]
        public double? ProductRating { get; set; }

        [JsonPropertyName("product_page_url")]
        public string ProductPageUrl { get; set; }

        [JsonPropertyName("product_offers_page_url")]
        public string ProductOffersPageUrl { get; set; }

        [JsonPropertyName("product_specs_page_url")]
        public string ProductSpecsPageUrl { get; set; }

        [JsonPropertyName("product_reviews_page_url")]
        public string ProductReviewsPageUrl { get; set; }

        [JsonPropertyName("product_num_reviews")]
        public int ProductNumReviews { get; set; }

        [JsonPropertyName("product_num_offers")]
        public string ProductNumOffers { get; set; }

        [JsonPropertyName("typical_price_range")]
        public List<string> TypicalPriceRange { get; set; }

        [JsonPropertyName("offer")]
        public OffersDTO Offer { get; set; }

        public List<OffersDTO> Offers { get; set; } = new List<OffersDTO>();
    }
}
