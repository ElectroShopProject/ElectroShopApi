using System.Collections.Generic;
using System.Linq;
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
            // TODO Save to DB
            return CreatePaymentUseCase.Create(amount, type);
        }

        public List<PaymentOption> GetPaymentOptions()
        {
            return PaymentOptionList;
        }

        public List<Payment> GetPayments()
        {
            // TODO Replace this with call to the DB
            return PaymentOptionList.Select(option => new Payment(Amount: 100, PaymentStatus: PaymentStatus.Progress, Type: option.Type)).ToList();
        }
    }
}
