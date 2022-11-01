using System.ComponentModel.DataAnnotations;

namespace vylka.Areas.Entity
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ShippingDetail> ShippingDetails { get; set; }
        public List<Product> Products { get; set; }
    }
}
