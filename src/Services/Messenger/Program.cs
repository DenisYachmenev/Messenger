var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessengerContext>( options =>
{
    options.UseSqlite( builder.Configuration.GetConnectionString( "Sqlite" ) );
} );

builder.Services.AddControllers().AddJsonOptions( x =>
                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles );

builder.Services.AddNotifier( builder.Configuration );
builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MessengerContext>();
    db.Database.EnsureCreated();
}
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();