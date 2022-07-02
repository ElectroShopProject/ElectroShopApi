using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class PaymentOptionType
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
