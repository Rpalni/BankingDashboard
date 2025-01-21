using BankingAPI.Contracts.BusinessLogic;
using BankingAPI.Contracts.Database;
using BankingAPI.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.BusinessLogic
{
    public class LoginBL : ILoginBL
    {
        private readonly ILoginDAL _loginDAL;

        public LoginBL(ILoginDAL loginDAL)
        {
            _loginDAL = loginDAL;
        }
        public async Task<List<Login>> GetLoginDetails()
        {
            var loginDetails = await _loginDAL.GetLoginDetails();
            return loginDetails;
        }
    }
}
