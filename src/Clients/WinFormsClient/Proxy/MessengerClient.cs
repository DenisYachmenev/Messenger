using Newtonsoft.Json;
using System.Text;
using WinFormsClient.Proxy.Models;

namespace WinFormsClient.Proxy;

internal class MessengerClient : BaseApi
{
    public MessengerClient( HttpClient client ) : base( client )
    {
    }

    public UserApi GetUser( string email )
    {
        var user = Call<User>( () => _client.GetAsync( $"/api/user/email/{email}" ).Result );

        return new UserApi( _client, user );
    }
}

internal class UserApi : BaseApi
{
    private readonly User _user;

    public UserApi( HttpClient client, User user ) : base( client )
    {
        _user = user;
    }

    public Chat[] GetChats()
    {
        return _user.Chats.ToArray();
    }

    public ChatApi GetChat( Guid id )
    {
        // А может и лишний, только через id
        var chat = Call<Chat>( () => _client.GetAsync( $"/api/chat/{id}" ).Result );

        return new ChatApi( _client, _user.Id, chat );
    }
}


internal class ChatApi : BaseApi
{
    private readonly Guid _userId;
    private readonly Chat _chat;

    public ChatApi( HttpClient client, Guid userId, Chat chat ) : base( client )
    {
        _userId = userId;
        _chat = chat;
    }

    public Models.Message AddMessage( string text )
    {
        var message = new Models.Message()
        {
            Text = text,
            UserId = _userId,
            ChatId = _chat.Id
        };

        var str = JsonConvert.SerializeObject( message );

        var content = new StringContent( str, Encoding.UTF8, "application/json" );
   

        return Call<Models.Message>( () => _client.PostAsync( $"/api/message", content ).Result );
    }

    public IReadOnlyCollection<Models.Message> GetMessages()
    {
        return Call<IReadOnlyCollection<Models.Message>>( () => _client.GetAsync( $"/api/message/chatId/{_chat.Id}" ).Result );
    }
}

internal class BaseApi
{
    protected HttpClient _client;

    public BaseApi( HttpClient client )
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
        throw new Exception();
    }
}

