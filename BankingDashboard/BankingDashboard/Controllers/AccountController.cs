using BankingDashboard.Helpers;
using BankingDashboard.Models;
using BankingDashboard.Models.Request;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using BankingDashboard.Models.Response;
using Microsoft.AspNetCore.Http;

namespace BankingDashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiHelper _apiHelper;
        private readonly IConfiguration _configuration;
        public AccountController(ApiHelper apiHelper, IConfiguration configuration)
        {
            _apiHelper = apiHelper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var login = new Models.Request.LoginRequest();

            login.UserName = username;
            login.Password = password;
            
            var response = await _apiHelper.PostAsync<BankingDashboard.Models.Request.LoginRequest, BankingDashboard.Models.Response.LoginResponse>(_configuration["APIURL:LoginAPI"], login);

            //admin, password
            // Replace this with actual authentication logic
            if (response.isSuccessStatusCode)
            {
                HttpContext.Session.SetString("AuthToken", response.token);
                //Redirect to dashboard on successful login
                return RedirectToAction("BankingDashboard", "BankingDashboard");
            }

            // Add an error message for invalid login
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

        public IActionResult Logout()
        {
            // Logic for logging out the user (clear session/cookies, etc.)
            return RedirectToAction("Login");            
        }
    }
}
