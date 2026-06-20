using Microsoft.AspNetCore.Identity;
using TicketverkaufMM.Models;

namespace TicketverkaufMM.Models;

public class User : IdentityUser
{
    public int UserId { get; set; }
    public string Vorname { get; set; } = string.Empty;
    public string Nachname { get; set; } = string.Empty;
    public ICollection<Event> Events { get; set; } = new List<Event>();
}