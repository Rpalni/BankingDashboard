using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.Contracts.BusinessLogic
{
    public interface IBankingDashboardBL
    {
        public Task<ActionResult<IEnumerable<FundTransfer>>> GetFundTransfersDetails();
    }
}
