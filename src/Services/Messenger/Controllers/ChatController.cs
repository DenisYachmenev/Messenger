[Route( "api/[controller]" )]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly MessengerContext _context;

    public ChatController( MessengerContext context )
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType( typeof( Message[] ), StatusCodes.Status200OK )]
    public async Task<ActionResult> GetChats() =>
        Ok( await _context.Chats.ToArrayAsync() );

    [HttpGet]
    [Route( "{id}" )]
    [ProducesResponseType( StatusCodes.Status404NotFound )]
    [ProducesResponseType( typeof( Chat ), StatusCodes.Status200OK )]
    public async Task<ActionResult> GetChat( Guid id )
    {
        var chat = await _context.Chats
            .Include( c => c.Users )
            .FirstOrDefaultAsync( c => c.Id == id );

        return chat == null
            ? NotFound()
            : Ok( chat );
    }

    [HttpPost]
    [ProducesResponseType( StatusCodes.Status201Created )]
    public async Task<ActionResult> Post( [FromBody] Chat body )
    {
        var chat = await _context.Chats.AddAsync( body );

        await _context.SaveChangesAsync();

        return Created( $"/chat/{chat.Entity.Id}", chat.Entity );
    }

    // TODO: Переделпть на Patch?
    [HttpPut]
    [Route( "{id}" )]
    [ProducesResponseType( StatusCodes.Status204NoContent )]
    [ProducesResponseType( StatusCodes.Status404NotFound )]
    public async Task<ActionResult> Put( Guid id, [FromBody] Guid[] userIds )
    {
        var chat = await _context.Chats.FirstOrDefaultAsync( c => c.Id == id );

        if( chat == null )
            return NotFound();

        var users = await _context.Users.Where( u => userIds.Contains( u.Id ) ).ToArrayAsync();

        // TODO: Попробовать LanguageEx 
        foreach( var user in users )
            chat.Users.Add( user );

        await _context.SaveChangesAsync();

        return NoContent();
    }
}