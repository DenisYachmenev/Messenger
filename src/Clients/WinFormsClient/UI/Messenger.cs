using WinFormsClient.Proxy;
using WinFormsClient.Proxy.Models;

namespace WinFormsClient;

internal partial class Messenger : Form
{
   /* private readonly User _user;

    private readonly IMessengerClient _client;

    public Messenger( IMessengerClient client, User user)
    {
        InitializeComponent();

        _client = client;
        _user = user;
        // TODO: разораться с биндингом
        listChats.DataSource = _user.Chats;
        listChats.DisplayMember = nameof( Chat.Name );
        listChats.SelectedIndex = -1;
        listChats.SelectedIndexChanged += new EventHandler( listChats_SelectedIndexChanged );
    }*/

    private void btnCreateChat_Click( object sender, EventArgs e )
    {

    }

    private void btnSend_Click( object sender, EventArgs e )
    {

    }

    private void listChats_SelectedIndexChanged( object sender, EventArgs e )
    {
        var chat = (Chat)listChats.SelectedItem;

       // listMessages.DataSource = _client.GetMessages( chat.Id );
        listChats.DisplayMember = nameof( Proxy.Models.Message.Text );
        //listChats.SelectedIndex = -1;
    }
}
