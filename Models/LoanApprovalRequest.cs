namespace AIOS.Models
{
    public class LoanApprovalRequest
    {
        public int CreditScore { get; set; }
        public decimal VehiclePrice { get; set; }
        public decimal DownPayment { get; set; }
        public int LoanTerm { get; set; }
        public string TermUnit { get; set; }
    }
}
