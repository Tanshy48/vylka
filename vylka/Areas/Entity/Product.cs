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
        public string Category { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
