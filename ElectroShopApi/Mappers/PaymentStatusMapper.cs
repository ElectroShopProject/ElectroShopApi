using System;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class PaymentStatusMapper
    {
        public static PaymentStatus Map(PaymentStatusTable table)
        {
            return Enum.Parse<PaymentStatus>(table.Name);
        }
    }
}
