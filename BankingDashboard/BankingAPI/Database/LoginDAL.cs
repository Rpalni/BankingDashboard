using BankingAPI.Contracts.Database;
using BankingAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Database
{
    public class LoginDAL : ILoginDAL
    {
        private readonly ApplicationDbContext _context;

        public LoginDAL(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Login>> GetLoginDetails()
        {
            var loginDetails = await _context.Login.ToListAsync();
            return loginDetails;
        }
    }
}
