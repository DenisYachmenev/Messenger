﻿namespace WinFormsClient.Proxy.Models;

internal class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Chat[] Chats { get; set; }
}