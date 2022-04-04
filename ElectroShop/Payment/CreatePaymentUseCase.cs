using System;
using ElectroShopApi.Domain.Payment;

namespace ElectroShopApi
{
    public class CreatePaymentUseCase
    {
        public static Payment Create(double amount, PaymentOptionType type)
        {
            // For now just return random payment status
            var statusType = typeof(PaymentStatus);
            var statusCount = Enum.GetNames(statusType).Length;
            var selectedStatus = new Random().Next(statusCount);
            var status = Enum.GetValues(statusType).GetValue(selectedStatus);

            return new Payment(
                Amount: amount,
                PaymentStatus: (PaymentStatus)status,
                Type: type
            );
        }
    }
}
