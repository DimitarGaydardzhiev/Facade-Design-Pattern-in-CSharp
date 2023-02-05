using Facade.Models;

namespace Facade.Services
{
    internal class PaymentService
    {
        internal bool ProcessCardPayment(decimal price, PaymentInfo paymentInfo)
        {
            var result = false;

            using (var client = new HttpClient())
            {
                // process payment request to the bank
            }

            return result;
        }
    }
}

