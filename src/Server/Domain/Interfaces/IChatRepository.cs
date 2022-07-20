public interface IChatRepository : IRepository<Chat>
{
    Task<IReadOnlyCollection<Chat>> ReadAsync( );
}