using Pensopay.Models;
using Pensopay.Models.Util;
using Pensopay.RequestParameters;
using Pensopay.Services;
using System.Diagnostics;

namespace Pensopay.Examples
{
    /*
         * Pensopay .NET SDK - Payments Examples
         * The following examples show how to create, capture, refund and cancel payments.
         */

    public class Payments
    {
        // We need to create a new instance of the PensopayClient PaymentService to use the payment methods.
        private static readonly PaymentService _paymentService = new PaymentService("<<BearerToken>>");

        /// <summary>
        /// Create a payment with a basket
        /// </summary>
        /// <returns></returns>
        public static async Task CreatePaymentWithBasket() // After v2 upgrade its no longer possible to create a payment without a basket
        {
            // First we need to create an address object, which we can use for the billing and shipping address.
            Address address = new() { name = "test", address = "test", city = "Copenhagen", country = "Denmark", email = "test@test.dk", mobile_number = "12345678", phone_number = "12345678", zipcode = "2300" };

            // We can now create an order object, which we can use to create a payment with a basket.
            Order order = new()
            {
                billing_address = address,
                shipping_address = address,
                // We can add items to the basket by adding Item objects to the Basket list.
                Basket = new() { new Item() { qty = 2, sku = "123test", name = "The Elder Wand", price = 10000, vat_rate = 25 } }
            };

            // We can now create a payment with the order object containing the basket and the address objects.
            var reqParams = new CreatePaymentRequestParams()
            {
                currency = "DKK",
                order_id = "12345678",
                amount = 100,
                order = order,
                testmode = true
            };

            Payment payment = await _paymentService.CreatePaymentAsync(reqParams);

            //We can now use the payment object to get the payment id, which we can use to capture, refund or cancel the payment. We can also use the payment object to get the payment url.
            Console.WriteLine(payment.link);

        }

        /// <summary>
        /// Capture a payment
        /// </summary>
        /// <returns></returns>
        public static async Task CapturePayment()
        {
            // We can now capture the payment by calling the CapturePayment method on the paymentService instance. The request returns the captured payment.
            Payment payment = await _paymentService.CapturePaymentAsync(12345678, 1000);

            Console.WriteLine(payment.captured);
        }

        /// <summary>
        /// Cancel a payment
        /// </summary>
        /// <returns></returns>
        public static async Task CancelPayent()
        {
            // We can now cancel the payment by calling the CancelPayment method on the paymentService instance. The request returns the cancelled payment.
            // !!! REMEMBER only payments in state "authorized" can be cancelled !!!.
            Payment payment = await _paymentService.CancelPaymentAsync(12345678);

            Console.WriteLine(payment.state);
        }

        /// <summary>
        /// Refund a payment
        /// </summary>
        public static async Task RefundPayent()
        {
            // We can now refund the payment by calling the RefundPayment method on the paymentService instance. The request returns the refunded payment.
            Payment payment = await _paymentService.RefundPaymentAsync(12345678, 1000);

            Console.WriteLine(payment.refunded);
        }
    }
}
