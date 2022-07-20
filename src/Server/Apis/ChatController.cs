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
    public async Task<IActionResult> GetChats() =>
        Ok( await _context.Chats.ToArrayAsync() );

    [HttpGet]
    [Route( "/chat/{id}" )]
    public async Task<IActionResult> GetChat( Guid id )
    {
        var chat = await _context.Chats
            .Where( c => c.Id == id )
            .Select( c => new { id = c.Id, name = c.Name, chats = c.Users.Select( c => c.Id ).ToArray() } )
            .FirstOrDefaultAsync();

        return chat == null
            ? NotFound()
            : Ok( chat );
    }

    [HttpPost]
    public async Task<IActionResult> Post( [FromBody] Chat body )
    {
        var chat = await _context.Chats.AddAsync( body );

        await _context.SaveChangesAsync();

        return Created( $"/chat/{chat.Entity.Id}", chat.Entity );
    }

    [HttpPut]
    [Route( "/chat/{id}" )]
    public async Task<IActionResult> Put( Guid id, [FromBody] Guid[] userIds )
    {
        var chat = await _context.Chats.FirstOrDefaultAsync( c => c.Id == id );

        if( chat == null )
            return NotFound( id );

        var users = await _context.Users.Where( u => userIds.Contains( u.Id ) ).ToArrayAsync();

        // TODO: Попробовать LanguageEx 
        foreach( var user in users )
            chat.Users.Add( user );

        await _context.SaveChangesAsync();

        return NoContent();
    }
}