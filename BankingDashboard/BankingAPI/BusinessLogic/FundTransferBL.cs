using BankingAPI.Contracts.BusinessLogic;
using BankingAPI.Contracts.Database;
using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.BusinessLogic.Controllers
{
    public class FundTransferBL: IFundTransferBL
    {
        private readonly IFundTransferDAL _fundTransferDAL;

        public FundTransferBL(IFundTransferDAL fundTransferDAL)
        {
            _fundTransferDAL = fundTransferDAL;
        }
        public async Task SaveFundTransfer(FundTransfer fundTransfer)
        {
           await _fundTransferDAL.SaveFundTransfer(fundTransfer);
        }
    }
}
