using EngEKatalog.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngEKatalog.Core.Abstract
{
    public interface IGetProdInfo
    {
        //public List<ProductIdListDTO> GetProdInfo();

        //Task<List<ApiResponseDTO>> GetProductByNameFromAPIList(string name);

        //Task<ApiResponseDTO> GetProductByNameFromAPI(string name);

        //Task<List<ProductIdListDTO>> GetProductIdFromAPIByName(string name);

        Task<List<ApiResponseDTONotList>> GetJsonItemByName(string name);

		Task<OffersResponseDTO> GetJsonOfferById(string id);

        Task<ApiResponseDTONotList> GetProductByIdFromAPIList1(string id);

        Task<ReviewsResponseDTO> GetReviewById(string id);
	}
}
