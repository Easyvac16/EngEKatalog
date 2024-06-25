using EngEKatalog.Core.Abstract;
using EngEKatalog.Core.DTOs;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace EngEKatalog.Core.Services
{
    public class ProductService : IGetProdInfo
    {
        private readonly HttpClient _httpClient;


        public ProductService()
        {


            _httpClient = new HttpClient();
        }


        public async Task<List<ApiResponseDTONotList>> GetJsonItemByName(string name)
        {

            var apiGamesContent1 = await GetProductByNameFromAPI(name);

            List<ApiResponseDTONotList> apiResponseDTO = new List<ApiResponseDTONotList>();
            
            if (apiGamesContent1 != null && apiGamesContent1.Data != null)
            {
                foreach (var productData in apiGamesContent1.Data)
                {
                    apiResponseDTO.Add(await GetProductByIdFromAPIList1(productData.product_id));

                }
            }
            else
            {
                Console.WriteLine("Invalid JSON response.");
            }
            return apiResponseDTO;
        }

		public async Task<OffersResponseDTO> GetJsonOfferById(string id)
		{

            var offerResponse = await GetOfferByIdFromAPIList(id);

			
			return offerResponse;
		}


		private async Task<ApiResponseDTO> GetProductByNameFromAPI(string name)
        {
            ApiResponseDTO apiResponseDTO = new ApiResponseDTO();

            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/search?q={name}&country=us&language=en&limit=9&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"));
            Console.WriteLine(request);
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiResponseDTO = JsonSerializer.Deserialize<ApiResponseDTO>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return apiResponseDTO ?? throw new Exception("products was null");
        }

        public async Task<ApiResponseDTONotList> GetProductByIdFromAPIList1(string id)
        {
            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/product-details?product_id={id}&country=us&language=en"));

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<ApiResponseDTONotList>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return products ?? throw new Exception("products was null");
            }
        } 
        private async Task<OffersResponseDTO> GetOfferByIdFromAPIList(string id)
        {
            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/product-offers?product_id={id}&page=1&country=us&language=en"));

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<OffersResponseDTO>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return products ?? throw new Exception("products was null");
            }
        }

        public async Task<ReviewsResponseDTO> GetReviewById(string id)
        {
            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/product-reviews?product_id={id}&limit=10&country=us&language=en"));
            
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var products = JsonSerializer.Deserialize<ReviewsResponseDTO>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return products ?? throw new Exception("products was null");
            }

        }

        private HttpRequestMessage GetApiRequestMessage(Uri uri)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri, //,
                Headers =
                {
                    { "X-RapidAPI-Key", "637942729amshcbfe1ed947c04afp15ffd7jsnd0058fa03688" },
                    { "X-RapidAPI-Host", "real-time-product-search.p.rapidapi.com" },
                },
            };
        }

        /*public List<ProductIdListDTO> GetProdInfo()
        {
            string json = File.ReadAllText("test1.json");

            List<ProductIdListDTO> productList = JsonSerializer.Deserialize<List<ProductIdListDTO>>(json);

            foreach (ProductIdListDTO product in productList)
            {
                Console.WriteLine($"Product ID: {product.ProductId}");

            }
            return productList;


        }*/


        /*public async Task<ProductDTO> Search(string name)
        {
            var apiProducts = await GetProductFullInfoFromAPI(name);
            var products = new List<ProductDTO>();

            foreach (ProductDTO apiProduct in apiProducts)
            {
                Console.Write($"Game: ");
                try
                {
                    var test = await GetProductFullInfoFromAPI(apiProduct.ProductTitle);
                    //test.ReviewsInsights = test.ReviewsInsights.Where(review => review. is not null);
                    var res = MapGame(test);
                    products.Add(res);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine();
            }
            return products;

        }*/

        /*public async Task<ApiResponseDTO> GetProductFullInfoFromAPI(string productName)
        {

            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/search?q={productName}&country=us&language=en&limit=30&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"));
            var product = await GetProductDTO(request);
            //product.Data.Product.ProductTitle = productName;

            return product;
        }*/



        /*public async Task<List<ApiResponseDTO>> GetProductByNameFromAPIList(string name)
        {
            var products = new List<ApiResponseDTO>();

            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/search?q={name}&country=us&language=en&limit=30&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"));
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                products = JsonSerializer.Deserialize<List<ApiResponseDTO>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return products ?? throw new Exception("products was null");
        }

        private async Task<ApiResponseDTO> GetProductByIdFromAPIList(string id)
        {
            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/product-details?product_id={id}&country=us&language=en"));

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<ApiResponseDTO>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return products ?? throw new Exception("products was null");
            }
        }*/



        /*public async Task<List<ProductIdListDTO>> GetProductIdFromAPIByName(string name)
        {
            *//*List<ProductIdListDTO> apiResponseDTO = new List<ProductIdListDTO>();

            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/search?q={name}&country=us&language=en&limit=1&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"));
            Console.WriteLine(request);
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiResponseDTO = JsonSerializer.Deserialize<List<ProductIdListDTO>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return apiResponseDTO ?? throw new Exception("products was null");*//*

            List<ProductIdListDTO> apiResponseDTO = new List<ProductIdListDTO>();

            var request = GetApiRequestMessage(new Uri($"https://real-time-product-search.p.rapidapi.com/search?q={name}&country=us&language=en&limit=1&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"));
            Console.WriteLine(request);

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON into ApiResponseDTO first to access the 'data' array
                var apiResponse = JsonSerializer.Deserialize<ApiResponseDTO>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Extract product_id values from each item in 'data' array
                if (apiResponse != null && apiResponse.Data != null)
                {
                    *//*foreach (var item in apiResponse.Data.ToList())
                    {
                        apiResponseDTO.Add(new ProductIdListDTO { ProductId = item.Product.ProductId });
                    }*//*
                }
                else
                {
                    throw new Exception("No products found for the given name");
                }
            }

            return apiResponseDTO;
        }*/



        /*private ProductDTO MapGame(ProductDTO productDTO)
        {
            var game = _iMapper.Map<ProductDTO>(productDTO);

            *//*
            game.Reviews = MapReviews(gameDTO.RecentReviews, game, true).ToList();
            game.Reviews.AddRange(MapReviews(gameDTO.RecentUserReviews, game, false));*//*

            return game;
        }*/






        /*private string FormatString(string str)
        {
            StringBuilder sb = new StringBuilder();

            str = str.Replace(' ', '-').ToLower();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '-' || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }*/
    }
}
