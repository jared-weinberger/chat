using System.ComponentModel.DataAnnotations;

namespace Data;
public abstract class Message
{
    [Required]
    public Guid Id { get; set; }

    [Key]
    [Required]
    public virtual Conversation? Conversation { get; set; }

    [Key]
    [Required]
    public virtual User? Author { get; set; }
}