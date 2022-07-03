using System;
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

        public PaymentService(
            PaymentTableContext context,
            PaymentOptionTypeTableContext optionTypeTableContext,
            PaymentStatusTableContext paymentStatusTableContext)
        {
            _context = context;
            _optionTypeTableContext = optionTypeTableContext;
            _paymentStatusTableContext = paymentStatusTableContext;
        }

        public async Task<Payment> GetPayment(double amount, PaymentOptionType type)
        {
            var paymentOptionTypes = await _optionTypeTableContext
                .PaymentOptionTypeTable
                .ToListAsync();

            var paymentStatuses = await _paymentStatusTableContext
                .PaymentStatusTable
                .ToListAsync();

            var payment = CreatePaymentUseCase.Create(amount, type);
            try
            {
                await _context.AddAsync(PaymentMapper.Map(
                    payment,
                    paymentOptionTypes,
                    paymentStatuses
                    ));

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't write payment to DB");
            }

            return payment;
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
