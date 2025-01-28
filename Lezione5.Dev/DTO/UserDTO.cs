using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lezione5.Dev.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public required string Nickname { get; set; }
    }

    public class NewUserDTO
    {
        [MinLength(8, ErrorMessage = "Il nickname deve essere lungo almeno 8 caratteri")]
        public required string Nickname { get; set; }
        [Compare("ConfirmPassword", 
            ErrorMessage = "La password e la conferma password devono corrispondere")]
        [MinLength(12, ErrorMessage = "La password deve essere lunga almeno 12 caratteri")]
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
