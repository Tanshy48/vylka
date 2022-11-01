using System.ComponentModel.DataAnnotations;

namespace vylka.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<ProductModel> Product { get; set; }
    }
}
