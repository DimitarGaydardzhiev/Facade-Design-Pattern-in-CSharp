using Facade.Models;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ticketFacade = new TicketFacade();

            var purchaseInfo = new PurchaseInfo()
            {
                BuyerInfo = new BuyerInfo()
                {
                    Email = "buyeremail@test.test",
                    Name = "Buyer"
                },
                GenerateInvoice = true,
                PaymentInfo = new PaymentInfo()
                {
                    CardExpirationDate = DateTime.Now.AddYears(3),
                    CardNumber = Guid.NewGuid().ToString(),
                    CardSecurityCode = "123"
                },
                SeatNumber = 42,
                TicketType = TicketType.Regular
            };

            ticketFacade.BuyTicket(purchaseInfo);
        }
    }
}
