using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vylka.Areas.Entity;

public class ShippingDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string District { get; set; }
    
    public string DeliveryType { get; set; }
    
    public float TotalPrice { get; set; }
    
    public DateTime CreateDelivery { get; set; }
    public Cart Cart { get; set; }
    public IdentityUser UserId { get; set; }

}