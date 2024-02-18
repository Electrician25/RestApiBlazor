using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RestApiBlazor.IntificationModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is requared!")]
        [EmailAddress(ErrorMessage = "This email is valid!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is requared!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}