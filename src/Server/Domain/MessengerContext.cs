public class MessengerContext : DbContext
{
    public MessengerContext( DbContextOptions<MessengerContext> options) : base(options) { }
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Chat> Chats => Set<Chat>();

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<User>()
        //            .HasMany( s => s.Chats )
        //            .WithMany( s => s.Users )
        //            .UsingEntity( j => j.ToTable( "ChatUser" ) );

        //modelBuilder.Entity<Chat>()
        //            .HasMany( s => s.Users )
        //            .WithMany( s => s.Chats )
        //            .UsingEntity( j => j.ToTable( "ChatUser" ) );
        
    }
}