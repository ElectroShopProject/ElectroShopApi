using System;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class PaymentOptionTypeMapper
    {
        public static PaymentOptionType Map(PaymentOptionTypeTable table)
        {
            return Enum.Parse<PaymentOptionType>(table.Name);
        }
    }
}
