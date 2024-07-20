using System.ComponentModel.DataAnnotations;

namespace DB
{
    public class User
    {

        [Required]
        public Guid id { get; set; }
        [Required]
        public string Handle { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
        public IEnumerable<Conversation> Conversations { get; set; } = [];
    }
}