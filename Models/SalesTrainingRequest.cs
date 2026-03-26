using System.Collections.Generic;

namespace AIOS.Models
{
    public class SalesTrainingRequest
    {
        public string Personality { get; set; }      // e.g. "Analytical", "Emotional"
        public string Scenario { get; set; }         // e.g. "PaymentTooHigh", "TradeInLow"
        public string UserMessage { get; set; }      // What the salesperson just said
        public List<SalesChatTurn> History { get; set; } = new();
    }

    public class SalesChatTurn
    {
        public string Role { get; set; }             // "salesperson" or "customer"
        public string Content { get; set; }
    }

    public class SalesTrainingResult
    {
        public string CustomerReply { get; set; }
        public string CoachComment { get; set; }
    }
}
