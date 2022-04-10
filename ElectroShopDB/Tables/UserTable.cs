using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class UserTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
