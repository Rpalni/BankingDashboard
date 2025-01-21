using BankingDashboard.Helpers;
using BankingDashboard.Models.Request;
using BankingDashboard.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace BankingDashboard.Controllers
{
    public class FundTransferController : Controller
    {
        private static List<FundTransferRequest> Transfers = new List<FundTransferRequest>();

        private readonly ApiHelper _apiHelper;
        private readonly IConfiguration _configuration;        

        public FundTransferController(ApiHelper apiHelper, IConfiguration configuration)
        {
            _apiHelper = apiHelper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult FundTransfer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  FundTransfer(FundTransferRequest fundTransfer)
        {
            if (ModelState.IsValid)
            {                
                FundTransferResponse response = await _apiHelper.PostAsync<FundTransferRequest, FundTransferResponse>(_configuration["APIURL:FundTransferAPI"], fundTransfer);                
                return RedirectToAction("BankingDashboard", "BankingDashboard");
            }

            return View(fundTransfer);
        }
    }
}
