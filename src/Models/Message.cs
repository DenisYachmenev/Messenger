public class Message
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public Status Status { get; set; } = Status.New;

    public Guid UserId { get; set; }
    public virtual User? User { get; set; }

    public Guid ChatId { get; set; }
    public virtual Chat? Chat { get; set; }
}