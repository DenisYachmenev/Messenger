﻿public class Chat
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}