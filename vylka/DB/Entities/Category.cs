namespace vylka.DB.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        
        public List<Product> Product { get; set; }
    }
}
