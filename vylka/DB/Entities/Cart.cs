namespace vylka.DB.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<Product> Product { get; set; }

    }
}
