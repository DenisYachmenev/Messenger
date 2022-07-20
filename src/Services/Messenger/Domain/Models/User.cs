public class User
{
    public Guid Id { get; set; }

    [Required, MaxLength( 50 )]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength( 50 )]
    public string Email { get; set; } = string.Empty;

    public ICollection<Chat> Chats { get; set; } = new HashSet<Chat>();
}