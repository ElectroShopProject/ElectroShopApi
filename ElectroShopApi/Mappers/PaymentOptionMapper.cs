using System;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class PaymentOptionMapper
    {
        public static PaymentOption Map(PaymentOptionTypeTable table)
        {
            var type = PaymentOptionTypeMapper.Map(table);
            // Simulates payment vendor changes
            var isAvailable = new Random().Next(2) == 0; // Bool

            return new PaymentOption(type, isAvailable);
        }
    }
}
