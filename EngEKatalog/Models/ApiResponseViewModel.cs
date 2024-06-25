using EngEKatalog.Core.DTOs;

namespace EngEKatalog.WEB.Models
{
    public class ApiResponseViewModel
    {
        public List<ApiResponseDTONotList>? apiResponses { get; set; }

        public OffersResponseDTO? offers { get; set; }

        public ApiResponseDTONotList? apiResponse { get; set; }

        public List<ReviewsDTO>? reviews { get; set; }
    }
}
