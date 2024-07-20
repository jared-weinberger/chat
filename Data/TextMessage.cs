using System.ComponentModel.DataAnnotations;

namespace Data;

public class TextMessage : Message
{
    [Required]
    public string Contents { get; set; }
}
