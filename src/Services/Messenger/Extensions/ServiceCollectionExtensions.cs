namespace Messager.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddNotifier(this IServiceCollection services, ConfigurationManager configuration )
    {
        services.AddSingleton<IRabbitMQPersisterConnection>( _ =>
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri( configuration[ "RabbitMQPersisterConnection:Uri" ] )
            };

            return new RabbitMQPersisterConnection( factory );
        } ).AddSingleton<IChatNotifier, ChatNotifier>();
    }
}
