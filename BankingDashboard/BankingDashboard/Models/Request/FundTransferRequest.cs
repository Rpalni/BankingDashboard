using System.ComponentModel.DataAnnotations;

namespace BankingDashboard.Models.Request
{
    public class FundTransferRequest
    {
        public int TransferId { get; set; }
        [Required]
        public string FromAccount { get; set; }

        [Required]
        public string ToAccount { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Range(0, float.MaxValue)]
        public float AccountBalance { get; set; }

        [Range(0, float.MaxValue)]
        public float DepositeAmount { get; set; }
    }
}
