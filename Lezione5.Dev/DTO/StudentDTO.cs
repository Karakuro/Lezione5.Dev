using System.ComponentModel.DataAnnotations;

namespace Lezione5.Dev.DTO
{
    public class StudentDTO
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [Phone(ErrorMessage = "Inserire un numero di telefono corretto")]
        public required string Phone { get; set; }
        [Length(16,16)]
        public required string FiscalCode { get; set; }
    }
}
