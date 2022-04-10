using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class TaxRateTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public double Percent { get; set; }
        [Required]
        public string ProductCategoryId { get; set; }
    }
}
