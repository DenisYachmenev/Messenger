public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository( MessageDb context, ILogger<MessageRepository> logger ) 
        : base( context, logger ) { }

    public override async Task<Message> GetAsync( Guid id )
    {
        return await _context.Messages.SingleOrDefaultAsync( m => m.Id == id );
    }

    public async Task<IReadOnlyCollection<Message>> ReadByChatIdAsync( Guid chatId )
    {
        return await _context.Messages.Where( m => m.ChatId == chatId ).ToListAsync();
    }

    public async Task<IReadOnlyCollection<Message>> ReadByUserIdAsync( Guid userId )
    {
        return await _context.Messages.Where( m => m.UserId == userId ).ToListAsync();
    }

    public override async Task<Message> CreateAsync( Message entity )
    {
        _logger.LogInformation( $"Add new message to '{entity.ChatId}' chat from user with id - {entity.UserId}." );
        return (await _context.Messages.AddAsync( entity )).Entity;
    }

    public override async Task DeletetAsync( Guid id )
    {
        var message = await _context.Messages
            .SingleOrDefaultAsync( m => m.Id == id );
        if( message == null ) return;

        _context.Messages.Remove( message );
    }
}