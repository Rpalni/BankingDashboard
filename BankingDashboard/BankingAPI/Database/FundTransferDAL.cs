using BankingAPI.Contracts.Database;
using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Database
{
    public class FundTransferDAL : IFundTransferDAL
    {
        private readonly ApplicationDbContext _context;

        public FundTransferDAL(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task SaveFundTransfer(FundTransfer fundTransfer)
        {
            _context.FundTransfer.Add(fundTransfer);
            await _context.SaveChangesAsync();
        }
    }
}
