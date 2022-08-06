using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.Proxy;
using WinFormsClient.Proxy.Models;

namespace WinFormsClient
{
    internal partial class AuthorizationForm : Form
    {
        private readonly MessengerClient _client;

        public AuthorizationForm(MessengerClient client)
        {
            InitializeComponent();

            _client = client;
        }

        private void btnSignIn_Click( object sender, EventArgs e )
        {
            var userApi = _client.GetUser( txtEmail.Text );

            // TODO: Добавить регистрацию если пользователь не найден

            this.Hide();

            var messager = new Messenger( userApi );
            messager.Closed += ( s, args ) => this.Close();
            messager.Show();
        }
    }
}
