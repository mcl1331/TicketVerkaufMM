namespace TicketverkaufMM.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime? Datum { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Reservierung> Reservierungen { get; set; } = new List<Reservierung>();

    }
}
