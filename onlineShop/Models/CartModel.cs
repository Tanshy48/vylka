using System.ComponentModel.DataAnnotations;

namespace onlineShop.Models
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
