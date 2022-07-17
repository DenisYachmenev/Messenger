public class MessageApi
{
    public void Register( WebApplication app )
    {
        app.MapGet( "/message/chatId/{chatId}", async ( Guid chatId, MessageDb context ) => {
            var messages = await context.Messages.Where( m => m.ChatId == chatId ).ToArrayAsync();

            return Results.Ok( messages );
        } );

        app.MapPost( "/message", async ( [FromBody] Message body, MessageDb context ) =>
        {
            var message = await context.Messages.AddAsync( body );

            await context.SaveChangesAsync();

            return Results.Created( $"/message/{message.Entity.Id}", message.Entity );
        } );

          //app.MapGet( "/message/{id}", async ( Guid id, MessageDb context ) =>

          //    await context.Messages.FirstOrDefaultAsync( m => m.Id == id ) is Message message
          //    ? Results.Ok( message )
          //    : Results.NotFound( id ) 
          //);

          //app.MapPut( "/message", async ( [FromBody] Message body, MessageDb context ) =>
          //{
          //    var message = await context.Messages.FirstOrDefaultAsync( m => m.Id == body.Id );

          //    if( message == null )
          //        return Results.NotFound( body.Id );

          //    message.Status = body.Status;

          //    await context.SaveChangesAsync();

          //    return Results.NoContent();
          //} );

          //app.MapDelete( "/message/{id}", async ( Guid id, MessageDb context ) =>
          //{
          //    var message = await context.Messages.FirstOrDefaultAsync( m => m.Id == id );

          //    if( message == null )
          //        return Results.NotFound( id );

          //    context.Messages.Remove( message );
          //    await context.SaveChangesAsync();

          //    return Results.NoContent();
          //} );
    }
}
