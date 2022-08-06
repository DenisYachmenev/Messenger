using WinFormsClient.Proxy;
using WinFormsClient.Proxy.Models;

namespace WinFormsClient;

internal partial class Messenger : Form
{
    private readonly UserApi _userApi;

    public Messenger( UserApi userApi )
    {
        InitializeComponent();

        _userApi = userApi;
        // TODO: разораться с биндингом
        listChats.DataSource = userApi.GetChats();
        listChats.DisplayMember = nameof( Chat.Name );
        listChats.SelectedIndex = -1;
        listChats.SelectedIndexChanged += new EventHandler( listChats_SelectedIndexChanged );
    }

    private void btnCreateChat_Click( object sender, EventArgs e )
    {

    }

    private void btnSend_Click( object sender, EventArgs e )
    {

    }

    private void listChats_SelectedIndexChanged( object sender, EventArgs e )
    {
        var chat = (Chat)listChats.SelectedItem;

        var chatApi = _userApi.GetChat( chat.Id );

        listMessages.DataSource = chatApi.GetMessages( );
        listMessages.DisplayMember = nameof( Proxy.Models.Message.Text );
        listMessages.SelectedIndex = -1;
    }
}
