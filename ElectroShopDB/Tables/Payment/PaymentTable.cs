using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class PaymentTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string PaymentStatusId { get; set; }
        [Required]
        public string PaymentOptionTypeId { get; set; }
    }
}
