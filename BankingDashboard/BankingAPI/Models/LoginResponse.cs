using System.ComponentModel.DataAnnotations;

namespace BankingAPI.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public bool IsSuccessStatusCode { get; set; }

    }
}
