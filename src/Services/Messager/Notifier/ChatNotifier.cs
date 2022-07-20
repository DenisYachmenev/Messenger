using RabbitMQ.Client;
using System.Text;

public class ChatNotifier : IChatNotifier
{
    private const string EXCHANGE_NAME = "ChatExchange";

    private readonly IRabbitMQPersisterConnection _persisterConnection;

    public ChatNotifier( IRabbitMQPersisterConnection connection)
    {
        _persisterConnection = connection;
    }

    public void Notify(string chatId)
    {
        if( !_persisterConnection.IsConnected )
            _persisterConnection.TryConnect();

        using( var channel = _persisterConnection.CreateModel() )
        {
            channel.ExchangeDeclare( EXCHANGE_NAME, ExchangeType.Direct );

            channel.BasicPublish( exchange: EXCHANGE_NAME,
                           routingKey: chatId,
                           basicProperties: null,
                           body: Encoding.UTF8.GetBytes( "" ) );
        }
    }
}