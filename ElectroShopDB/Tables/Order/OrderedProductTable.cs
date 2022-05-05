using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class OrderedProductTable
    {
        [Key]
        public string OrderId { get; set; }
        [Key]
        public string ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
