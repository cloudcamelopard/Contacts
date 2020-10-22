namespace ContactsServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UseRole { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}
