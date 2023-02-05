using Facade.Models;
using Facade.Services;

namespace Facade
{
    public class TicketFacade
    {
        private const decimal RegularTicketPrice = 1000m;

        private const decimal VIPTicketPrice = 2000m;

        public void BuyTicket(PurchaseInfo purchaseInfo)
        {
            // 1. Set the seat as reserved
            this.SetSeatStatus(purchaseInfo.SeatNumber, SeatStatus.Reserverd);

            // 2. Process the payment
            var paymentService = new PaymentService();
            var price = this.GetPrice(purchaseInfo.TicketType);
            bool isPaymentSuccessful = paymentService.ProcessCardPayment(price, purchaseInfo.PaymentInfo);

            if (isPaymentSuccessful)
            {
                // 3. Generate reciept, ticket and invoice
                var printService = new PrintService();
                string reciept = printService.PrintReciept(price);
                string ticket = printService.PrintTicket(price, purchaseInfo.BuyerInfo.Name, purchaseInfo.SeatNumber);

                string invoice = string.Empty;
                if (purchaseInfo.GenerateInvoice)
                {
                    invoice = printService.PrintInvoice(price, purchaseInfo.BuyerInfo.Name);
                }

                // 4. Send the generated items via email to the buyer
                var emailSenderService = new EmailSenderService();
                emailSenderService.SendEmail(purchaseInfo.BuyerInfo.Email, reciept, ticket, invoice);
            }
            else
            {
                // If payment fails - unreserve the seat
                this.SetSeatStatus(purchaseInfo.SeatNumber, SeatStatus.NotReserved);
            }
        }

        private decimal GetPrice(TicketType ticketType)
        {
            var price = RegularTicketPrice;
            if (ticketType == TicketType.VIP)
                price = VIPTicketPrice;

            return price;
        }

        private void SetSeatStatus(int seatNumber, SeatStatus seatStatus)
        {
            // a Database call to mark the seleced seat as reserved/unrserved
        }
    }
}
