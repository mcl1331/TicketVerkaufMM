namespace TicketverkaufMM.Models
{
    public class Tisch
    {
        public int TischId { get; set; } 
        public ICollection<Tisch> Tische { get; set; } = new List<Tisch>();
    }
}
