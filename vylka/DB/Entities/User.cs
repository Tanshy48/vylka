namespace vylka.DB.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Roles Roles { get; set; }
        public List<ShippingDetail> ShippingDetail { get; set; }
        public Cart Cart { get; set; }

    }
}
