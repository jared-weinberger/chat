using System.ComponentModel.DataAnnotations;

namespace Data;

public class TextMessage : Message
{
    [Required]
    public required string Contents { get; set; }
}
