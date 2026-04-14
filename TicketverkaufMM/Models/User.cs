namespace TicketverkaufMM.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Vorname { get; set; } = string.Empty;
        public string Nachname { get; set; } = string.Empty;
        public string Email { get; set; } 
        public string Password { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
