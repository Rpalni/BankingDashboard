using BankingAPI.Database.Entities;

namespace BankingAPI.Contracts.Database
{
    public interface IFundTransferDAL
    {
        public Task SaveFundTransfer(FundTransfer fundTransfer);
    }
}
