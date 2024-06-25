using EngEKatalog.Core.Abstract;
using EngEKatalog.Core.DTOs;
using EngEKatalog.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EngEKatalog.WEB.Controllers
{
    public class ApiResponseController : Controller
    {
        private readonly IGetProdInfo _getProdInfo;

        public ApiResponseController(IGetProdInfo getProdInfo)
        {
            _getProdInfo = getProdInfo;
        }

        [HttpGet]
        public async Task<IActionResult> List(string nameRequest)
        {
            var viewModel = new ApiResponseViewModel();

            nameRequest = Request.Query["q"].FirstOrDefault();

            var products = await _getProdInfo.GetJsonItemByName(nameRequest);
            if (nameRequest is not null)
            {
                products = products
                   .Where(product => product.Data.Product.ProductTitle.ToLower()
                   .Contains(nameRequest.ToLower()))
                   .ToList();
                viewModel.apiResponses = products;
            }


            return View(viewModel);
        }

		public async Task<IActionResult> Details(string id)
		{
            var viewModel = new ApiResponseViewModel
            {
                offers = new OffersResponseDTO(),
                apiResponse = new ApiResponseDTONotList(),
                reviews = new List<ReviewsDTO>()
            };

			var product = await _getProdInfo.GetProductByIdFromAPIList1(id);	

			var offer = await _getProdInfo.GetJsonOfferById(id);

            var reviews = await _getProdInfo.GetReviewById(id);

			if (viewModel.offers.Data == null)
			{
				viewModel.offers.Data = new OffersWithDTO
				{
					Offers = new List<OffersDTO>() 
				};
			}

            foreach(var item in reviews.Data.Reviews)
            {
                viewModel.reviews.Add(item);
            }
            

			viewModel.offers.Data.ProductRating = offer.Data.ProductRating;
			viewModel.offers.Data.NumberReviews = offer.Data.NumberReviews;

			viewModel.apiResponse = product;

            foreach (var item in offer.Data.Offers)
            {
                viewModel.apiResponse.Data.Product.Offers.Add(item);
            }

            return View(viewModel);
		}
	}
}

