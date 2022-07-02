using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class PaymentStatusTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
