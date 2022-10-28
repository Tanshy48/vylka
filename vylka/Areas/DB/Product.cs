using System.ComponentModel.DataAnnotations;

namespace vylka.Areas.DB
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}
