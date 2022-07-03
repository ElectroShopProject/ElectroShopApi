using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop;
using ElectroShopApi.Mappers;
using ElectroShopDB;
using Microsoft.EntityFrameworkCore;

namespace ElectroShopApi
{
    public class PaymentService
    {
        private readonly PaymentTableContext _context;
        private readonly PaymentOptionTypeTableContext _optionTypeTableContext;
        private readonly PaymentStatusTableContext _paymentStatusTableContext;

        public Payment GetPayment(double amount, PaymentOptionType type)
        {
            // TODO Save to DB
            return CreatePaymentUseCase.Create(amount, type);
        }

        public async Task<List<PaymentOption>> GetPaymentOptions()
        {
            var paymentOptionTypes = await _optionTypeTableContext
                .PaymentOptionTypeTable
                .ToListAsync();

            return await _optionTypeTableContext
                .PaymentOptionTypeTable
                .Select(table => PaymentOptionMapper.Map(table))
                .ToListAsync();
        }

        public async Task<List<Payment>> GetPayments()
        {
            var paymentOptions = await _optionTypeTableContext
                .PaymentOptionTypeTable
                .ToListAsync();

            var paymentStatuses = await _paymentStatusTableContext
                 .PaymentStatusTable
                 .ToListAsync();

            return await _context
                .PaymentTable
                .Select(table => PaymentMapper.Map(table, paymentOptions, paymentStatuses))
                .ToListAsync();
        }
    }
}
