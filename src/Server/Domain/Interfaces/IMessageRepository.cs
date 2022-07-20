public interface IMessageRepository : IRepository<Message>
{
    Task<IReadOnlyCollection<Message>> ReadByChatIdAsync( Guid chatId );
    Task<IReadOnlyCollection<Message>> ReadByUserIdAsync( Guid userId );
}