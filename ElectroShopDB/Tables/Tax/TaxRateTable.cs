using System.ComponentModel.DataAnnotations;

namespace ElectroShopApi
{
    public class TaxRateTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public double Amount { get; set; }

        // Foreign Key
        [Required]
        public string ProductCategoryId { get; set; }
        // Reference Model
        public ProductCategoryTable ProductCategoryTable { get; set; }
    }
}
