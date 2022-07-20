var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessengerContext>( options =>
{
    options.UseSqlite( builder.Configuration.GetConnectionString( "Sqlite" ) );
} );

// TODO: Перенести в расширение
builder.Services
    .AddSingleton<IRabbitMQPersisterConnection>( _ =>
    {
        var factory = new ConnectionFactory()
        {
            Uri = new Uri( builder.Configuration[ "RabbitMQPersisterConnection:Uri" ] )
        };

        return new RabbitMQPersisterConnection( factory );
    } ).AddSingleton<IChatNotifier, ChatNotifier>();

builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if( app.Environment.IsDevelopment() )
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MessengerContext>();
    db.Database.EnsureCreated();
}
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();