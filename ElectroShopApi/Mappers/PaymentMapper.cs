using System;
using System.Collections.Generic;
using System.Linq;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class PaymentMapper
    {
        public static Payment Map(
            PaymentTable table,
            List<PaymentOptionTypeTable> paymentOptionTypeTables,
            List<PaymentStatusTable> paymentStatusTables)
        {
            var foundStatus = paymentStatusTables
                .Find(statusTable => statusTable.Id == table.PaymentStatusId);

            var foundType = paymentOptionTypeTables
                .Find(paymentOptionTable => paymentOptionTable.Id == table.PaymentOptionTypeId);

            return new Payment(Amount: table.Amount,
                PaymentStatus: PaymentStatusMapper.Map(foundStatus),
                Type: PaymentOptionTypeMapper.Map(foundType)
                ) with
            { Id = table.Id.ToGuid() };
        }
    }
}
