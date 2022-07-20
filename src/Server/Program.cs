var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessengerContext>( options =>
{
    options.UseSqlite( builder.Configuration.GetConnectionString( "Sqlite" ) );
} );

builder.Services
  .AddSingleton<IChatNotifier, ChatNotifier>( sp =>
  {
      return new ChatNotifier() { Address = builder.Configuration[ "ChatNotifier:Address" ] };
  } );

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