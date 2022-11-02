using System.ComponentModel.DataAnnotations;

namespace vylka.Areas.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
