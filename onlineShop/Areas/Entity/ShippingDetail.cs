#nullable disable
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineShop.Areas.Entity;

public class ShippingDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string District { get; set; }
    
    public string DeliveryType { get; set; }
    
    public double TotalPrice { get; set; }
    
    public DateTime CreateDelivery { get; set; }
    public string UserId { get; set; }
    
    public virtual IdentityUser User { get; set; }

}