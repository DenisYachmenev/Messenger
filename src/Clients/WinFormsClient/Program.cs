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

        var user = client.GetUserByEmail( "email" );

        Guid[] guids = user.GetChats();

        ChatClient chat = user.GetChat( guids[ 0 ] );

        chat.GetMessages();

        chat.AddMessage("test");

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        //Application.Run(new AuthorizationForm( client ) );
    }
}