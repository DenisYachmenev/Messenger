var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

Configure(app);
new MessageApi().Register(app);

app.Run();

void RegisterServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddLogging();
    services.AddScoped<IMessageRepository, MessageRepository>();
    services.AddScoped<IChatRepository, ChatRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddDbContext<MessageDb>(options =>
    {
        options.UseSqlite(configuration.GetConnectionString("Sqlite"));
    });
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MessageDb>();
        db.Database.EnsureCreated();
    }
    app.UseHttpsRedirection();
}
