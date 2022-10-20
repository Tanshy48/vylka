using System.ComponentModel.DataAnnotations;

namespace vylka.Areas.DB
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
