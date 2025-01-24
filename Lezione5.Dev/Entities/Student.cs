namespace Lezione5.Dev.Entities
{
    public class Student
    {
        private static int seeder = 1;
        public int Id { get; set; } = seeder++;
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string FiscalCode { get; set; }
    }
}
