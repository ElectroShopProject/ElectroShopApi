using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectroShopDB
{
    public class OrderedProductTable
    {
        // Key
        [Key]
        [Required]
        public string OrderId { get; set; }
        // Key
        [Key]
        [Required]
        public string ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
