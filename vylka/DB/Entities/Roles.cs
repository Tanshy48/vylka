namespace vylka.DB.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public List<User> User { get; set; }

    }
}
