using System.ComponentModel.DataAnnotations;

namespace mvvm1.Pages
{
    public class Account
    {
        [Required(ErrorMessage = "Please enter your student name.")]
        public string AccountName { get; set; }
         [Required(ErrorMessage = "Please enter your account number.")]
         [Range(0, 9999999999, ErrorMessage = "Use 0-9 only number ")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Graduation Year.")]
        [Range(1900, 2025, ErrorMessage = "Please set the year from 1900 to 2025.")]
        public string Gradyear { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address.")]
        [RegularExpression(@"[\w!#$%&'*+/=?^_@{}\\|~-]+(\.[\w!#$%&'*+/=?^_{}\\|~-]+)*@([\w][\w-]*\.)+[\w][\w-]*",
         ErrorMessage = "E-mail address is incorrect.")]
        public string EMailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your Password.")]
        public string password { get; set; }
    }
}