#nullable disable

using System.ComponentModel.DataAnnotations;

namespace vylka.Models
{
    public class CategoryModel
    {
        
        [Required]
        public string Name { get; set; }
    }
}
