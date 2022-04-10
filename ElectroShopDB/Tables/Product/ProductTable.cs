using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class ProductTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double NetPrice { get; set; }
        [Required]
        public double GrossPrice { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        [Required]
        public string ManufacturerId { get; set; }
    }
}
