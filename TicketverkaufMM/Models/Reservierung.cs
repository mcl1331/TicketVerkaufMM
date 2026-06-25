namespace TicketverkaufMM.Models
{
    public class Reservierung
    {
        public int Id { get; set; }
        public int Personenanzahl { get; set; }
        public int TischId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime Datum { get; set; }
    }
}