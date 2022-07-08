public class ChatRepository : Repository<Chat>, IChatRepository
{
    public ChatRepository( MessageDb context, ILogger<MessageRepository> logger ) 
        : base( context, logger ) { }

    public override async Task<Chat> CreateAsync( Chat entity )
    {
        return (await _context.Chats.AddAsync( entity )).Entity;
    }

    public override async Task DeletetAsync( Guid id )
    {
        var chat = await _context.Chats
            .SingleOrDefaultAsync( c => c.Id == id );
        if( chat == null ) return;

        _context.Chats.Remove( chat );
    }

    public override async Task<Chat> GetAsync( Guid id )
    {
        return await _context.Chats.SingleOrDefaultAsync( c => c.Id == id );
    }

    public async Task<IReadOnlyCollection<Chat>> ReadAsync( Guid userId )
    {
        throw new NotImplementedException();
        //return await _context.Chats.Where( c => c.Users == userId ).ToListAsync();
    }
}