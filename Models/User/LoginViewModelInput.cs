using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.User
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "E-mail is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
