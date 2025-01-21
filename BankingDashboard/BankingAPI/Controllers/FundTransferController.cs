using BankingAPI.Contracts.BusinessLogic;
using BankingAPI.Database;
using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FundTransferController : ControllerBase
    {
        private readonly IFundTransferBL _fundTransferbl;
        public FundTransferController(IFundTransferBL fundTransferbl)
        {            
            _fundTransferbl = fundTransferbl;
        }
        [Authorize(AuthenticationSchemes = "Jwt")]
        [HttpPost]
        public async Task<IActionResult> SaveFundTransfer([FromBody] FundTransfer fundTransfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _fundTransferbl.SaveFundTransfer(fundTransfer);
            return Ok(new { Message = "Fund transfer saved successfully!", fundTransfer });
        }
    }
}
