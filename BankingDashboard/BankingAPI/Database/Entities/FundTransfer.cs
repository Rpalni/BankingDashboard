using System.ComponentModel.DataAnnotations;

namespace BankingAPI.Database.Entities
{
    public class FundTransfer
    {
        [Key]
        public int TransferId { get; set; }
        [Required]
        public string FromAccount { get; set; }

        [Required]
        public string ToAccount { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Range(0, double.MaxValue)]
        public double AccountBalance { get; set; }

        [Range(0, double.MaxValue)]
        public double DepositeAmount { get; set; }
    }
}
