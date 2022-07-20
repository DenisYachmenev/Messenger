public class ChatApi
{
    public void Register( WebApplication app )
    {
        app.MapGet( "/chat", async ( IChatRepository repository ) =>
            Results.Ok( await repository.ReadAsync() )
        );

        app.MapGet( "/chat/{id}", async ( Guid id, IChatRepository repository ) =>
            Results.Ok( await repository.GetAsync( id ) )
        );

        app.MapPost( "/chat", async ( [FromBody] Chat body, IChatRepository repository ) =>
        {
            var chat = await repository.CreateAsync( body );

            await repository.SaveAsync();

            return Results.Created( $"/chat/{chat.Id}", chat );
        } );

        app.MapDelete( "/chat/{id}", async ( Guid id, IChatRepository repository ) =>
        {
            var chat = await repository.GetAsync( id );

            if( chat == null )
                return Results.NotFound( id );

            await repository.DeletetAsync( chat.Id );
            await repository.SaveAsync();

            return Results.NoContent();
        } );
    }
}

