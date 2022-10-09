namespace vylka.DB.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Category Category { get; set; }
    }
}
