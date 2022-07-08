public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository( MessageDb context, ILogger<MessageRepository> logger ) 
        : base( context, logger ) { }

    public override async Task<User> CreateAsync( User entity )
    {
        return (await _context.Users.AddAsync( entity )).Entity;
    }

    public override async Task DeletetAsync( Guid id )
    {
        var user = await _context.Users
            .SingleOrDefaultAsync( c => c.Id == id );
        if( user == null ) return;

        _context.Users.Remove( user );
    }

    public override async Task<User> GetAsync( Guid id )
    {
        return await _context.Users.SingleOrDefaultAsync( u => u.Id == id );
    }

    public async Task<IReadOnlyCollection<User>> ReadAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public Task<IReadOnlyCollection<User>> ReadAsync( Guid chatId )
    {
        throw new NotImplementedException();
    }
}