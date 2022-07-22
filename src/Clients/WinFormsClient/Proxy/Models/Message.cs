namespace WinFormsClient.Proxy.Models;

internal class Message
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public Status Status { get; set; } = Status.New;
    public DateTime DateTime { get; set; } = DateTime.Now;

    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
}

