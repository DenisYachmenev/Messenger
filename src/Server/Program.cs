var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessageDb>( options =>
{
    options.UseSqlite( builder.Configuration.GetConnectionString( "Sqlite" ) );
} );

var app = builder.Build();

if( app.Environment.IsDevelopment() )
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MessageDb>();
    db.Database.EnsureCreated();
}
// app.UseHttpsRedirection();

new MessageApi().Register(app);
new ChatApi().Register( app );
new UserApi().Register( app );

app.Run();