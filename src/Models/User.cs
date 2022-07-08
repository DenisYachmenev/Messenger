public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
}