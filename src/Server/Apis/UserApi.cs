public class UserApi
{
    public void Register( WebApplication app )
    {
        app.MapGet( "/user", async ( IUserRepository repository ) =>
            Results.Ok( await repository.ReadAsync() )
        );

        app.MapGet( "/user/{id}", async ( Guid id, IUserRepository repository ) =>
            Results.Ok( await repository.GetAsync( id ) )
        );

        app.MapPost( "/user", async ( [FromBody] User body, IUserRepository repository ) =>
        {
            var user = await repository.CreateAsync( body );

            await repository.SaveAsync();

            return Results.Created( $"/user/{user.Id}", user );
        } );

        app.MapDelete( "/user/{id}", async ( Guid id, IUserRepository repository ) =>
        {
            var user = await repository.GetAsync( id );

            if( user == null )
                return Results.NotFound( id );

            await repository.DeletetAsync( user.Id );
            await repository.SaveAsync();

            return Results.NoContent();
        } );
    }
}
