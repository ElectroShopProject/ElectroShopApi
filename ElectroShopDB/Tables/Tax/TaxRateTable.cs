using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class TaxRateTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public double Amount { get; set; }

        // Foreign Key
        [Required]
        public int ProductCategoryId { get; set; }
        // Reference Model
        public ProductCategoryTable ProductCategoryTable { get; set; }
    }
}
