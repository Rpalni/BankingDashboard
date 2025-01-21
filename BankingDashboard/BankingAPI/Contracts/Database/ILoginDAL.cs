using BankingAPI.Database.Entities;

namespace BankingAPI.Contracts.Database
{
    public interface ILoginDAL
    {
        public Task<List<Login>> GetLoginDetails();
    }
}
