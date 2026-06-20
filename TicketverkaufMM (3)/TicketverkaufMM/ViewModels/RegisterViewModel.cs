using System.ComponentModel.DataAnnotations;

namespace TicketverkaufMM.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "E-Mail ist erforderlich.")]
        [EmailAddress(ErrorMessage = "Keine gültige E-Mail-Adresse.")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Passwort ist erforderlich.")]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Passwort bestätigen ist erforderlich.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwörter stimmen nicht überein.")]
        [Display(Name = "Passwort bestätigen")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}