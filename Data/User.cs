using System.ComponentModel.DataAnnotations;

namespace Data;
public class User
{

    [Required]
    public Guid Id { get; set; }

    [Key]
    [Required]
    public required string Handle { get; set; }

    public string? GivenName { get; set; }

    public string? FamilyName { get; set; }

    public virtual IEnumerable<Conversation> Conversations { get; set; } = [];

    public byte[]? PasswordHash { get; set; }
}