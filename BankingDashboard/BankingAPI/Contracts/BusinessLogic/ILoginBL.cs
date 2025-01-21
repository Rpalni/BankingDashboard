using BankingAPI.Database.Entities;

namespace BankingAPI.Contracts.BusinessLogic
{
    public interface ILoginBL
    {
        public Task<List<Login>> GetLoginDetails();
    }
}
