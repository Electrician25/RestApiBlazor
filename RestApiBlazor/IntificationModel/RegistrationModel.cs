using System.ComponentModel.DataAnnotations;

namespace RestApiBlazor.IntificationModel
{
    public class RegistrationModel : LoginModel
    {
        [Required(ErrorMessage = "Confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password is not correct")]
        public string? Confirm { get; set; }
    }
}