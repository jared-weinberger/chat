using System.ComponentModel.DataAnnotations;

namespace Data;

public class Conversation
{
    [Required]
    public IEnumerable<User> Participants { get; set; }
}