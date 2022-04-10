using System.Collections.Generic;
using System.Linq;

namespace ElectroShop
{
    public class GetPaymentRequirmentUseCase
    {
        public static PaymentRequirment Get(
            CartSummary summary,
            List<PaymentOption> paymentOptions
        )
        {
            if (summary.GrossTotal <= 0.0)
            {
                return new PaymentRequirment(
                    Amount: 0.0,
                    AvailablePaymentOptions: new List<PaymentOptionType>()
                );
            }

            var availableOptions = paymentOptions
                .Where(option => option.IsAvailable)
                .Select(optionType => optionType.Type)
                .ToList();

            return new PaymentRequirment(
                Amount: summary.GrossTotal,
                availableOptions
           );
        }
    }
}
