using System.ComponentModel.DataAnnotations;

namespace BankingDashboard.Models.Request
{
    public class LoginRequest
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
