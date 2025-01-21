using System.ComponentModel.DataAnnotations;

namespace BankingDashboard.Models.Response
{
    public class LoginResponse
    {
        public string token { get; set; }
        public bool isSuccessStatusCode { get; set; }
    }
}
