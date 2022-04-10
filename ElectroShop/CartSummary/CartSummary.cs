using System.Collections.Generic;

namespace ElectroShop
{
    public record CartSummary(
        List<SummaryProduct> Products,
        double NetTotal,
        double GrossTotal
    );
}
