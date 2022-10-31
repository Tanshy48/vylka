using System.ComponentModel.DataAnnotations;

namespace vylka.Models
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
