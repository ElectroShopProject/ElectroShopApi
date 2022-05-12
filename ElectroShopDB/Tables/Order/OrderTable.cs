using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class OrderTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string CartId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string PaymentId { get; set; }
    }
}
