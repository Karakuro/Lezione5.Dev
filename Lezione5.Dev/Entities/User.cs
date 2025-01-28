namespace Lezione5.Dev.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Nickname { get; set; }
        public required string Password { get; set; }
    }
}
