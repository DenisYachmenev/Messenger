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
    [ProducesResponseType( typeof( Message[] ), StatusCodes.Status200OK )]
    public async Task<ActionResult> Get( Guid chatId ) => 
        Ok( await _context.Messages.Where( m => m.ChatId == chatId ).ToArrayAsync() );

    // TODO: А может переделать на userId/{userId}/chatId/{chatId} а в теле тест передавать?
    [HttpPost]
    [ProducesResponseType( StatusCodes.Status201Created )]
    public async Task<ActionResult> Post( [FromBody] Message body )
    {
        var message = await _context.Messages.AddAsync( body );

        await _context.SaveChangesAsync();

        _notifier.Notify( body.ChatId.ToString() );

        return Created( $"/message/{message.Entity.Id}", message.Entity );
    }
}