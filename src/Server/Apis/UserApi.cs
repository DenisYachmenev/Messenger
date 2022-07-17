public class UserApi
{
    public void Register( WebApplication app )
    {
        app.MapGet( "/user", async ( MessageDb context ) =>
            Results.Ok( await context.Users.ToArrayAsync() )
        );

        app.MapGet( "/user/name/{name}/email/{email}", async ( string name, string email,  MessageDb context ) =>
            await context.Users.Include( u => u.Chats/*.Select(c => c.Id )*/ ).FirstOrDefaultAsync( u => u.Name == name && u.Email == email ) is User user
            ? Results.Ok( user )
            : Results.NotFound( )
        );

        app.MapPost( "/user", async ( [FromBody] User body, MessageDb context ) =>
        {
            var user = await context.Users.AddAsync( body );

            await context.SaveChangesAsync();

            return Results.Created( $"/user/{user.Entity.Id}", user.Entity );
        } );

        //app.MapGet( "/user/{id}", async ( Guid id, MessageDb context ) =>
        //    await context.Users.Include( u => u.Chats ).FirstOrDefaultAsync( u => u.Id == id ) is User user
        //    ? Results.Ok( user )
        //    : Results.NotFound( id )
        //);

        //app.MapDelete( "/user/{id}", async ( Guid id, MessageDb context ) =>
        //{
        //    var user = await context.Users.FirstOrDefaultAsync( u => u.Id == id );

        //    if( user == null )
        //        return Results.NotFound( id );

        //    context.Users.Remove( user );
        //    await context.SaveChangesAsync();

        //    return Results.NoContent();
        //} );
    }
}