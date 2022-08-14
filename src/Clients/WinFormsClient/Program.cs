using Newtonsoft.Json;
using WinFormsClient.Proxy;
using WinFormsClient.Proxy.Models;
using Microsoft.Extensions.Configuration;

namespace WinFormsClient;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        using var httpClient = new HttpClient()
        {
            BaseAddress = new Uri( GetSettings().ServiceUri )
        };

        var client = new MessengerClient( httpClient );

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run( new AuthorizationForm( client ) );

        // client.AddUser();

        //var userApi = client.GetUser( "tester@yandex.ru" );

        //var chatGuids = userApi.GetChats();

        //var chatApi = userApi.GetChat( chatGuids[0] );

        ////userApi.AddChat();

        ////var messageApi = chatApi.GetMessages();

        //chatApi.AddMessage( "Hello!" );
    }

    private static Settings GetSettings() => new ConfigurationBuilder()
             .AddJsonFile( "appsettings.json" )
             .Build()
             .Get<Settings>();
}