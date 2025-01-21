using BankingDashboard.Helpers;
using BankingDashboard.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BankingDashboard.Controllers
{
    public class BankingDashboardController : Controller
    {

        private readonly ApiHelper _apiHelper;
        private readonly IConfiguration _configuration;
        public BankingDashboardController(ApiHelper apiHelper, IConfiguration configuration)
        {
            _apiHelper = apiHelper;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> BankingDashboard()
        {            
            var fundTransfers = await _apiHelper.CallApiAsync<object, List<FundTransferRequest>>(_configuration["APIURL:BankingDashboardAPI"], HttpMethod.Get);
            return View(fundTransfers);
        }
    }
}
