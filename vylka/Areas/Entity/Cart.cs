using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vylka.Areas.Entity
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsActive { get; set; }
        
        public DateTime CreateCart { get; set; }

        public IdentityUser CartUserId { get; set; }

        public List<CartItem>? CartItem { get; set; }


    }
}
