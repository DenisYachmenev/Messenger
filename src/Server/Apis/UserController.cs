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
    public async Task<IActionResult> GetUsers() =>
        Ok( await _context.Users.ToArrayAsync() );

    [HttpGet]
    [Route( "name/{name}/email/{email}" )]
    public async Task<IActionResult> GetUser( string name, string email )
    {
        var user = await _context.Users
            .Where( u => u.Name == name && u.Email == email )
            .Select( u => new { id = u.Id, name = u.Name, chats = u.Chats.Select( c => c.Id ).ToArray() } )
            .FirstOrDefaultAsync();

        return user == null
            ? NotFound()
            : Ok( user );
    }

    [HttpPost]
    public async Task<IActionResult> Post( [FromBody] User body )
    {
        var user = await _context.Users.AddAsync( body );

        await _context.SaveChangesAsync();

        return Created( $"/user/{user.Entity.Id}", user.Entity );
    }
}