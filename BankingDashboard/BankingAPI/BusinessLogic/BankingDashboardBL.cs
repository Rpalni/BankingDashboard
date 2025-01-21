using BankingAPI.Contracts.BusinessLogic;
using BankingAPI.Contracts.Database;
using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.BusinessLogic
{
    public class BankingDashboardBL: IBankingDashboardBL
    {
        private readonly IBankingDashboardDAL _bankingDashboardDAL;

        public BankingDashboardBL(IBankingDashboardDAL bankingDashboardDAL)
        {
            _bankingDashboardDAL = bankingDashboardDAL;
        }
        public async Task<ActionResult<IEnumerable<FundTransfer>>> GetFundTransfersDetails()
        {
            return await _bankingDashboardDAL.GetFundTransfersDetails();
        }
    }
}
