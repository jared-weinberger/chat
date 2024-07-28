using Microsoft.EntityFrameworkCore;

namespace Data;

public class StorageContext(string connectionString) : DbContext
{
    private readonly string connectionString = connectionString;

    public DbSet<User> Users { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
}
