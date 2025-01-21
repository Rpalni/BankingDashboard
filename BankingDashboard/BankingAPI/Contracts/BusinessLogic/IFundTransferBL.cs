using BankingAPI.Database.Entities;

namespace BankingAPI.Contracts.BusinessLogic
{
    public interface IFundTransferBL
    {
        public Task SaveFundTransfer(FundTransfer fundTransfer);
    }
}
