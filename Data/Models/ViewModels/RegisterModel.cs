using System.ComponentModel.DataAnnotations;

namespace BilgiKutuphanesiWebApp.Data.Models.ViewModels
{
    public class RegisterModel  
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Mail adresi gerekli!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Gerekli!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre ve onay şifresi eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

    }
}
