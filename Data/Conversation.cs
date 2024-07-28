using System.ComponentModel.DataAnnotations;

namespace Data;

public class Conversation
{
    public Guid Id { get; set; }
    [Key]
    [Required]
    public virtual IEnumerable<User> Participants { get; set; } = [];
    public virtual IEnumerable<Message> Messages { get; set; } = [];
}