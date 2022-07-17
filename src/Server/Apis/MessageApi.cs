public class MessageApi
{
    public void Register( WebApplication app )
    {
        app.MapGet( "/message/{id}", async ( Guid id, IMessageRepository repository ) =>
            Results.Ok( await repository.GetAsync( id ) )
        );

        app.MapPost( "/message", async ( [FromBody] Message body, IMessageRepository repository ) =>
        {
            var message = await repository.CreateAsync( body );

            await repository.SaveAsync();

            return Results.Created( $"/message/{message.Id}", message );
        } );

        app.MapPut( "/message", async ( [FromBody] Message body, IMessageRepository repository ) =>
        {
            var message = await repository.GetAsync( body.Id );

            if( message == null )
                return Results.NotFound( body.Id );

            message.Text = body.Text;
            message.Status = body.Status;
            
            await repository.SaveAsync();

            // Тут наверное какоей-то другой стутус надо возвращать
            return Results.Ok( message );
        } );

        app.MapDelete( "/message/{id}", async ( Guid id, IMessageRepository repository ) =>
        {
            var message = await repository.GetAsync( id );

            if( message == null )
                return Results.NotFound( id );

            await repository.DeletetAsync( message.Id );
            await repository.SaveAsync();

            return Results.NoContent();
        } );
    }
}
