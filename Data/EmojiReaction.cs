using System.ComponentModel.DataAnnotations;

namespace Data;

public class EmojiReaction : Reaction
{
    [Required]
    public char Emoji { get; set; }
}
