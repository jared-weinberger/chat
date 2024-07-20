using Microsoft.EntityFrameworkCore;

namespace Data;

public class StorageContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Message> Messages { get; set; }
}
