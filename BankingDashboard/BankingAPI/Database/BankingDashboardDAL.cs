using BankingAPI.Contracts.Database;
using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Database
{
    public class BankingDashboardDAL: IBankingDashboardDAL
    {
        private readonly ApplicationDbContext _context;

        public BankingDashboardDAL(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ActionResult<IEnumerable<FundTransfer>>> GetFundTransfersDetails()
        {
            return await _context.FundTransfer.ToListAsync();
        }
    }
}
