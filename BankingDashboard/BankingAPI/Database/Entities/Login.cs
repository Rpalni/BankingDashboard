using System.ComponentModel.DataAnnotations;

namespace BankingAPI.Database.Entities
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
