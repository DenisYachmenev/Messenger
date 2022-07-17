public class ChatApi
{
    public void Register( WebApplication app )
    {
        app.MapGet( "/chat", async ( Guid userId, MessageDb context ) =>
            Results.Ok( await context.Chats.ToArrayAsync() )
        );

        app.MapGet( "/chat/{id}", async ( Guid id, MessageDb context ) =>
            await context.Chats.FirstOrDefaultAsync( c => c.Id == id ) is Chat chat
            ? Results.Ok( chat )
            : Results.NotFound( id ) 
        );

        app.MapPost( "/chat", async ( [FromBody] Chat body, MessageDb context ) =>
        {
            var chat = await context.Chats.AddAsync( body );

            await context.SaveChangesAsync();

            return Results.Created( $"/chat/{chat.Entity.Id}", chat.Entity );
        } );

        app.MapPut( "/chat/{id}", async ( Guid id, [FromBody] Guid[] userIds, MessageDb context ) =>
        {
            var chat = await context.Chats.FirstOrDefaultAsync( c => c.Id == id );

            if( chat == null )
                return Results.NotFound( id );

            // TODO: Переделать на массив
            var users = await context.Users.Where( u => userIds.Contains(u.Id) ).ToArrayAsync();

            // TODO: Попробовать LanguageEx 
            foreach( var user in users )
                chat.Users.Add( user );

            await context.SaveChangesAsync();

            return Results.NoContent();
        } );

        //app.MapGet( "/chat", async ( Guid userId, MessageDb context ) =>
        //    Results.Ok( await context.Chats.ToArrayAsync() )
        //);

        //app.MapDelete( "/chat/{id}", async ( Guid id, MessageDb context/*, IChatRepository repository*/ ) =>
        //{
        //    var chat = await context.Chats.FirstOrDefaultAsync( c => c.Id == id );

        //    if( chat == null )
        //        return Results.NotFound( id );

        //    context.Chats.Remove( chat );

        //    await context.SaveChangesAsync();

        //    return Results.NoContent();
        //} );
    }
}

