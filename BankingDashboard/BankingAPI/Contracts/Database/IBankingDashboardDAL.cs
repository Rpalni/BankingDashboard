using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPI.Contracts.Database
{
    public interface IBankingDashboardDAL
    {
        public Task<ActionResult<IEnumerable<FundTransfer>>> GetFundTransfersDetails();
    }
}
