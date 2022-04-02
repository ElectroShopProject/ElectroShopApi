using System;
using System.Collections.Generic;

namespace ElectroShopApi.Services
{
    public class PaymentService
    {

        private readonly List<PaymentOption> PaymentOptionList = new()
        {
            new PaymentOption(PaymentOptionType.CreditCard, IsAvailable: true),
            new PaymentOption(PaymentOptionType.BankTransfer, IsAvailable: true),
            new PaymentOption(PaymentOptionType.PayPal, IsAvailable: true),
            new PaymentOption(PaymentOptionType.Cash, IsAvailable: false)
        };

        public PaymentService()
        {
        }


        public List<PaymentOption> GetPaymentOptions()
        {
            return PaymentOptionList;
        }
    }
}
