using Newtonsoft.Json;
using WinFormsClient.Proxy;
using WinFormsClient.Proxy.Models;

namespace WinFormsClient;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var httpClinet = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5157")
        };

        var client = new MessengerClient( httpClinet );

        // client.AddUser();

        //var userApi = client.GetUser( "tester@yandex.ru" );

        //var chatGuids = userApi.GetChats();

        //var chatApi = userApi.GetChat( chatGuids[0] );

        ////userApi.AddChat();

        ////var messageApi = chatApi.GetMessages();

        //chatApi.AddMessage( "Hello!" );

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new AuthorizationForm( client ) );
    }
}