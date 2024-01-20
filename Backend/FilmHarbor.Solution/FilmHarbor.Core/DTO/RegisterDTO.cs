using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "User Name can't be blank")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password can't be blank")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
