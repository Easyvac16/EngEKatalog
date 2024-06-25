using EngEKatalog.Core.SomeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngEKatalog.Core.DTOs
{
    public class OffersDTO
    {
        [JsonPropertyName("store_name")]
        public string StoreName { get; set; }

        [JsonPropertyName("store_rating")]

        [JsonConverter(typeof(StringToDoubleConverter))]
        public double? StoreRating { get; set; } // Use Nullable<double> to handle nulls

        [JsonPropertyName("offer_page_url")]
        public string OfferPageUrl { get; set; }

        [JsonPropertyName("store_review_count")]
        public int StoreReviewCount { get; set; }

        [JsonPropertyName("store_reviews_page_url")]
        public string StoreReviewsPageUrl { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("shipping")]
        public string Shipping { get; set; }

        [JsonPropertyName("tax")]
        public string Tax { get; set; }

        [JsonPropertyName("on_sale")]
        public bool OnSale { get; set; }

        [JsonPropertyName("original_price")]
        public string OriginalPrice { get; set; }

        [JsonPropertyName("product_condition")]
        public string ProductCondition { get; set; }

        [JsonPropertyName("top_quality_store")]
        public bool TopQualityStore { get; set; }
    }
}
