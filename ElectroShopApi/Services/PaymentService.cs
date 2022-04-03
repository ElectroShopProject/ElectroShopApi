using System;
using System.Collections.Generic;
using ElectroShopApi.Domain.Payment;

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

        public Payment GetPayment(double amount)
        {
            return CreatePaymentUseCase.Create(amount);
        }

        public List<PaymentOption> GetPaymentOptions()
        {
            return PaymentOptionList;
        }
    }
}
