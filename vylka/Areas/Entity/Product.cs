using System.ComponentModel.DataAnnotations;

namespace vylka.Areas.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Cart> Carts { get; set; }

    }
}
