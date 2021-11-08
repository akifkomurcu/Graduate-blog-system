using System.ComponentModel.DataAnnotations;

namespace mvvm1.Pages
{
    public class LoginData
    {
        [Required(ErrorMessage = "Please enter your e-mail.")]
        [StringLength(50, ErrorMessage = "The user ID is too long.")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [StringLength(32, ErrorMessage = "The password is too long.")]
        public string Password { get; set; }
    }
}