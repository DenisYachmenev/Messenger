public abstract class Repository<T> : IRepository<T>
{
    protected readonly MessageDb _context;
    protected readonly ILogger<MessageRepository> _logger;

    public Repository( MessageDb context, ILogger<MessageRepository> logger )
    {
        _context = context;
        _logger = logger;
    }

    public abstract Task<T> CreateAsync( T entity );

    public abstract Task DeletetAsync( Guid id );

    public abstract Task<T> GetAsync( Guid id );

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}