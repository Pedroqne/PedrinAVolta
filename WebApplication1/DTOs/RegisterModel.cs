using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }


    }
}
