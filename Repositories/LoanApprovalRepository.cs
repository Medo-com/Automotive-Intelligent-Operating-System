using AIOS.Models;

namespace AIOS.Repositories
{
    public class LoanApprovalRepository
    {
        public object CalculateApproval(LoanApprovalRequest req)
        {
            // AI-style scoring logic
            double scoreFactor = req.CreditScore / 8.5;
            double dpFactor = Math.Min((double)req.DownPayment / (double)req.VehiclePrice * 100, 20);
            double termFactor = req.LoanTerm > 72 ? -10 : 5;

            int probability = (int)Math.Clamp(scoreFactor + dpFactor + termFactor, 5, 99);

            return new
            {
                probability,
                reason = GetReason(probability)
            };
        }

        private string GetReason(int pct)
        {
            if (pct >= 80)
                return "Strong approval likelihood due to high credit score and balanced loan structure.";

            if (pct >= 60)
                return "Moderate approval likelihood. Consider a slightly higher down payment.";

            if (pct >= 40)
                return "Approval could be challenging. A shorter term or higher down payment may help.";

            return "Low approval likelihood. Credit score or loan structure may require adjustment.";
        }
    }
}
