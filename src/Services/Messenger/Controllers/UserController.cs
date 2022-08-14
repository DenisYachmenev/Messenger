[Route( "api/[controller]" )]
[ApiController]
public class UserController : ControllerBase
{
    private readonly MessengerContext _context;

    public UserController( MessengerContext context )
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType( typeof( User[] ), StatusCodes.Status200OK )]
    public async Task<ActionResult> GetUsers() =>
        Ok( await _context.Users.ToArrayAsync() );

    [HttpGet]
    [Route( "email/{email}" )]
    [ProducesResponseType( StatusCodes.Status404NotFound )]
    [ProducesResponseType( typeof( User ), StatusCodes.Status200OK )]
    public async Task<ActionResult> GetUser( string email )
    {
        // TODO: Валидация. если не проходит то BadRequest
        var user = await _context.Users
            .Include(u => u.Chats )
            .FirstOrDefaultAsync( u => u.Email == email );

        return user == null
            ? NotFound()
            : Ok( user );
    }

    [HttpPost]
    [ProducesResponseType( StatusCodes.Status201Created )]
    public async Task<ActionResult> Post( [FromBody] User body )
    {
        var user = await _context.Users.AddAsync( body );

        await _context.SaveChangesAsync();

        return Created( $"/user/{user.Entity.Id}", user.Entity );
    }
}