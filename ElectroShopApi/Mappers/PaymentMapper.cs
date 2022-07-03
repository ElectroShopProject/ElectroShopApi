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

        public static PaymentTable Map(
            Payment payment,
            List<PaymentOptionTypeTable> paymentOptionTypeTables,
            List<PaymentStatusTable> paymentStatusTables)
        {
            var foundType = paymentOptionTypeTables
                .Find(type => PaymentOptionTypeMapper.Map(type) == payment.Type);

            var foundStatus = paymentStatusTables
                .Find(status => PaymentStatusMapper.Map(status) == payment.PaymentStatus);


            return new PaymentTable
            {
                Id = payment.Id.ToString(),
                Amount = payment.Amount,
                PaymentOptionTypeId = foundType.Id,
                PaymentStatusId = foundStatus.Id
            };
        }
    }
}
