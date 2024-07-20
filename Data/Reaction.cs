using System.ComponentModel.DataAnnotations;

namespace Data;

public abstract class Reaction
{
    [Required]
    public Guid Id { get; set; }
}