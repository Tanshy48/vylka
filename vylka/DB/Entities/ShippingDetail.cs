namespace vylka.DB.Entities
{
    public class ShippingDetail
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double AmountPaid { get; set; }
        public string PaymentType { get; set; }

        public User User { get; set; }
    }
}
