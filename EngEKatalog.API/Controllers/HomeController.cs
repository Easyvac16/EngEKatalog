using EngEKatalog.Core.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EngEKatalog.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetProdInfo _prodInfo;

        public HomeController(IGetProdInfo getProdInfo) 
        {
            _prodInfo = getProdInfo;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        [HttpGet("GetString", Name = "GetJson")]
        public async Task<IActionResult> Getjson()
        {

            //var test = _prodInfo.GetProdInfo(); //_prodInfo.GetProductByNameFromAPI("Nike");

            var test = await _prodInfo.GetJsonItemByName("");

            return Ok(test);
        }
        
        [HttpGet("GetProd", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct()
        {

            //var test = await _prodInfo.GetProductIdFromAPIByName("iphone"); //await _prodInfo.GetProductByNameFromAPI("Iphone");

            return Ok("200");
        }
    }
}
