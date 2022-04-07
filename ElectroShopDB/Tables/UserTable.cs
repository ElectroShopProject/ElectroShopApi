using System.ComponentModel.DataAnnotations;

namespace ElectroShopApi.Tables
{
    public class UserTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
