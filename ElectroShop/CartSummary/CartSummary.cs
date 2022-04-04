using System.Collections.Generic;
using ElectroShopApi.Domain.CartSummary;

namespace ElectroShopApi.Domain.Summary
{
    public record CartSummary(
        List<SummaryProduct> Products,
        double NetTotal,
        double GrossTotal
    );
}
