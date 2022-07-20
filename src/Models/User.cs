public class User
{
    public Guid Id { get; set; }

    [Required, MaxLength( 50 )]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength( 50 )]
    public string Email { get; set; } = string.Empty;

    public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();

    public virtual ICollection<Chat> Chats { get; set; } = new HashSet<Chat>();
}