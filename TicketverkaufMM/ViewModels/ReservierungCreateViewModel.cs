using System.ComponentModel.DataAnnotations;

namespace TicketverkaufMM.ViewModels
{
    public class ReservierungCreateViewModel
    {
        [Required(ErrorMessage = "Bitte Personenanzahl eingeben.")]
        [Range(1, 100, ErrorMessage = "Mindestens 1 Person")]
        [Display(Name = "Personenanzahl")]
        public int Personenanzahl { get; set; }

        [Required(ErrorMessage = "Bitte Tisch auswählen.")]
        [Display(Name = "Tisch")]
        public int TischId { get; set; }

        [Required(ErrorMessage = "Bitte Eventname eingeben.")]
        [Display(Name = "Eventname")]
        public string EventName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bitte Datum eingeben.")]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; } = DateTime.Today;
    }
}