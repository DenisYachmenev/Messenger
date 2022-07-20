using WinFormsClient.Proxy.Models;

namespace WinFormsClient;

internal partial class Messager : System.Windows.Forms.Form
{
    private User _user;

    public Messager(User user)
    {
        InitializeComponent();

        _user = user;
        // TODO: разораться с биндингом
        listChats.DataSource = _user.Chats;
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

        MessageBox.Show( $"{chat.Id} - {chat.Name}" );
    }
}
