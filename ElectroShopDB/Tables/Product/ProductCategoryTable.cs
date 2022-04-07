using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class ProductCategoryTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
