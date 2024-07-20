using System.ComponentModel.DataAnnotations;

namespace Data;
public abstract class Message
{
    [Required]
    public Guid Id { get; set; }
}