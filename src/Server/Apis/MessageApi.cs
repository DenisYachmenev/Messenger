public class MessageApi
{
    public void Register(WebApplication app)
    {
        app.MapPost("/get", async ( Guid id, IMessageRepository repository) =>
            Results.Ok(await repository.GetAsync( id ) )
        );

        app.MapPost("/add", async ([FromBody] Message body, IMessageRepository repository ) =>
        {
            var message = await repository.CreateAsync( body );

            await repository.SaveAsync();

            return Results.Created( $"/message/{message.Id}", message );
        });

        app.MapPost("/delete", async (Guid id, IMessageRepository repository ) =>
        {
            var message = (await repository.GetAsync( id ));

            if ( message == null)
                return Results.NoContent();

            await repository.DeletetAsync(message.Id);
            await repository.SaveAsync();

            return Results.NoContent();
        });
    }
}