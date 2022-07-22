using Newtonsoft.Json;
using WinFormsClient.Proxy.Models;

namespace WinFormsClient.Proxy;

internal class MessengerClient : BaseClient
{
    public MessengerClient( HttpClient client ) : base( client )
    {
    }

    public UserClient GetUserByEmail( string email )
    {
        var user = Call<User>( () => _client.GetAsync( $"/api/user/email/{email}" ).Result );

        return new UserClient( user, _client );
    }
}

internal class UserClient : BaseClient
{
    private readonly User _user;

    public UserClient( User user, HttpClient client ) : base( client )
    {
        _user = user;
    }


}


internal class ChatClient : BaseClient
{
    private readonly Guid _userId;
    private readonly Guid _chatId;

    public ChatClient( HttpClient client, Guid userId, Guid chatId ) : base( client )
    {
        _userId = userId;
        _chatId = userId;
    }

    public void AddMessage( string text )
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<Models.Message> GetMessages()
    {
        return Call<IReadOnlyCollection<Models.Message>>( () => _client.GetAsync( $"/api/message/chatId/{_chatId}" ).Result );
    }
}

internal class BaseClient
{
    protected HttpClient _client;

    public BaseClient(HttpClient client )
    {
        _client = client;
        // List<string> t;
        // t.FirstOrDefault()
        //public static TSource? FirstOrDefault<TSource>( this IEnumerable<TSource> source, Func<TSource, bool> predicate );
    }

    protected TResult Call<TResult>( Func<HttpResponseMessage> func)
    {
        var response = func();
        if( response.IsSuccessStatusCode )
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TResult>( content );
        }
    }
}

/*
internal interface IMessengerClient
{
    User? GetUserByEmailOrDefault( string email );

    //void AddNewUser( string name, string email );

    IEnumerable<Models.Message> GetMessages( Guid chatId );

    void AddMessage( Guid userId, Guid chatId, string text );
}*/
/*
internal class MessengerClient : IMessengerClient
{
    private readonly HttpClient _httpClient;

    public MessengerClient( HttpClient httpClinet )
    {
        _httpClient = httpClinet;
    }

    public void AddMessage( Guid userId, Guid chatId, string text )
    {
        var response = _httpClient.PostAsync( $"/api/message", null ).Result;
    }

    public IEnumerable<Models.Message> GetMessages( Guid chatId )
    {
        var response = _httpClient.GetAsync( $"/api/message/chatId/{chatId}" ).Result;
        if( response.IsSuccessStatusCode )
        {
            var content = response.Content.ReadAsStringAsync().Result;
            var messages = JsonConvert.DeserializeObject<List<Models.Message>>( content );
            return messages;
        }
        return Enumerable.Empty<Models.Message>();
    }

    public User? GetUserByEmailOrDefault( string email )
    {
        var response = _httpClient.GetAsync( $"/api/user/email/{email}" ).Result;
        if( response.IsSuccessStatusCode )
        {
            var content = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>( content );
            return user;
        }
        return default;
    }


}*/

