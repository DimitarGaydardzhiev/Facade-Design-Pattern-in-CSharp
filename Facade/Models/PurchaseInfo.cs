namespace Facade.Models
{
    public class PurchaseInfo
    {
        public TicketType TicketType { get; set; }

        public int SeatNumber { get; set; }

        public BuyerInfo BuyerInfo { get; set; }

        public bool GenerateInvoice { get; set; } = false;

        public PaymentInfo PaymentInfo { get; set; }
    }
}
