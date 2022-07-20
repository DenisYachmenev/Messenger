using RabbitMQ.Client;
using System.Text;

public class ChatNotifier : IChatNotifier
{
    public string Address { get; set; } = "";

    public void Notify(string chatId)
    {
        var factory = new ConnectionFactory() { Uri = new Uri(Address) };
        using( var connection = factory.CreateConnection() )
        using( var channel = connection.CreateModel() )
        {
            channel.ExchangeDeclare( "ChatExchange", ExchangeType.Direct );

            var body = Encoding.UTF8.GetBytes( "" );

            channel.BasicPublish( exchange: "MyExchange",
                           routingKey: chatId,
                           basicProperties: null,
                           body: body );
        }
    }
}