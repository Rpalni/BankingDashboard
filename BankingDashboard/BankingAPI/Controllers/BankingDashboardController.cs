using BankingAPI.Contracts.BusinessLogic;
using BankingAPI.Database;
using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingDashboardController : Controller
    {        
        private readonly IBankingDashboardBL _bankingDashboardbl;

        public BankingDashboardController(IBankingDashboardBL bankingDashboardbl)
        {
            _bankingDashboardbl = bankingDashboardbl;
        }

        // GET: api/FundTransfer
        [Authorize(AuthenticationSchemes = "Jwt")]
        [HttpGet("GetFundTransfersDetails")]        
        public async Task<ActionResult<IEnumerable<FundTransfer>>> GetFundTransfersDetails()
        {
            return await _bankingDashboardbl.GetFundTransfersDetails();
        }
    }
}
