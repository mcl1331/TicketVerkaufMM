using System.Reflection.Emit;

namespace TicketverkaufMM.Models
{
    public class Reservierung
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TischId { get; set; }
        public string EventName { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();

        public Tisch? Tisch { get; set; }
    }
}