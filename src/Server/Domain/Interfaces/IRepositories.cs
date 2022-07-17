public interface IRepository<T>
{
    Task<T> GetAsync( Guid id );
    Task<T> CreateAsync( T entity );
    //Task<T> UpdateAsync(T message);
    Task DeletetAsync( Guid id );
    Task SaveAsync();
}