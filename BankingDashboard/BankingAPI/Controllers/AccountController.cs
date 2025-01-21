using BankingAPI.Helper;
using BankingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BankingAPI.Contracts.BusinessLogic;
using BankingAPI.Database.Entities;

namespace BankingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ILoginBL _loginbl;

        //public AccountController(ApplicationDbContext context, IJwtTokenGenerator jwtTokenGenerator)
        public AccountController(ILoginBL loginbl, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
            _loginbl = loginbl;
        }

        // Post: api/FundTransfer
        [HttpPost("Login")]
        public async Task<ActionResult<IEnumerable<Login>>> Login([FromBody] Login request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loginDetails = await _loginbl.GetLoginDetails();

            if (Common.Encrypt(request.UserName) == loginDetails.FirstOrDefault().UserName && Common.Encrypt(request.Password) == loginDetails.FirstOrDefault().Password)
            {
                var token = _jwtTokenGenerator.GenerateToken(request.UserName, "Admin");
                var response = new LoginResponse
                {
                    Token = token,
                    IsSuccessStatusCode = true
                };
                return Ok(response);
            }
            return Unauthorized();
        }
    }
}
