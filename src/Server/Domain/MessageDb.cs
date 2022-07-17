public class MessageDb : DbContext
{
    public MessageDb(DbContextOptions<MessageDb> options) : base(options) { }
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Chat> Chats => Set<Chat>();

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating(modelBuilder);
    }
}