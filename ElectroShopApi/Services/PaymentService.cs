using System.Collections.Generic;
using ElectroShop;

namespace ElectroShopApi
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

        public Payment GetPayment(double amount, PaymentOptionType type)
        {
            return CreatePaymentUseCase.Create(amount, type);
        }

        public List<PaymentOption> GetPaymentOptions()
        {
            return PaymentOptionList;
        }
    }
}
