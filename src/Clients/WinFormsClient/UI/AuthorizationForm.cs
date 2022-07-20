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
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click( object sender, EventArgs e )
        {
            var messageWrapper = new MessageWrapper( "http://localhost:5157" );

            User? user = messageWrapper.GetUserByEmailOrDefault( txtEmail.Text );

            // TODO: Добавить регистрацию если пользователь не найден

            this.Hide();
            var messager = new Messager( user );
            messager.Closed += ( s, args ) => this.Close();
            messager.Show();
        }
    }
}
