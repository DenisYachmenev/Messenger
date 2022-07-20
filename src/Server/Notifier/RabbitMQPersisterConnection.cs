// https://github.com/dotnet-architecture/eShopOnAzure/blob/master/src/BuildingBlocks/EventBus/EventBusRabbitMQ/DefaultRabbitMQPersisterConnection.cs
public class RabbitMQPersisterConnection : IRabbitMQPersisterConnection
{
    private readonly IConnectionFactory _factory;

    IConnection _connection;
    private bool disposedValue;

    public RabbitMQPersisterConnection(IConnectionFactory factory)
    {
        _factory = factory ?? throw new ArgumentNullException( nameof( factory ) );
    }

    public bool IsConnected => _connection != null && _connection.IsOpen;

    public IModel CreateModel()
    {
        if( !IsConnected )
            throw new InvalidOperationException(  );

        return _connection.CreateModel();
    }

    public bool TryConnect()
    {
        _connection = _factory.CreateConnection();

        return IsConnected;
    }

    protected virtual void Dispose( bool disposing )
    {
        if( !disposedValue )
        {
            if( disposing && _connection != null )
                _connection.Dispose();
            
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose( disposing: true );
        GC.SuppressFinalize( this );
    }
}