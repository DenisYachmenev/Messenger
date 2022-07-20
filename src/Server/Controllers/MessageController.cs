[Route( "api/[controller]" )]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IChatNotifier _notifier;
    private readonly MessengerContext _context;

    public MessageController( MessengerContext context, IChatNotifier notifier )
    {
        _notifier = notifier;
        _context = context;
    }

    [HttpGet]
    [Route( "chatId/{chatId}" )]
    public async Task<IActionResult> Get( Guid id, Guid chatId )
    {
        var messages = await _context.Messages.Where( m => m.ChatId == chatId ).ToArrayAsync();

        return Ok( messages );
    }

    [HttpPost]
    public async Task<IActionResult> Post( [FromBody] Message body )
    {
        var message = await _context.Messages.AddAsync( body );

        await _context.SaveChangesAsync();

        _notifier.Notify( body.ChatId.ToString() );

        return Created( $"/message/{message.Entity.Id}", message.Entity );
    }
}