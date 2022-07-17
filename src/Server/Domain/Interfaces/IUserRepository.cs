public interface IUserRepository : IRepository<User>
{
    Task<IReadOnlyCollection<User>> ReadAsync();
    Task<IReadOnlyCollection<User>> ReadAsync( Guid chatId );
}