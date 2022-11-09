#nullable disable

using System.ComponentModel.DataAnnotations;

namespace vylka.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
