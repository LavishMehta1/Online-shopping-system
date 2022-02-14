using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShoppingCilent
{
    public partial class LoginForm : Form
    {
        string accountno, host, Current_user;
        private readonly IShopperdata m_session;
        public LoginForm(IShopperdata session)
        {
            InitializeComponent();
            m_session = session;
            button_connect.Enabled = false;
        }

        private async void button_connect_Click(object sender, EventArgs e)
        {

            try
            {
                host = textBox_hostname.Text;
                m_session.Server(host);
                await m_session.Connect(accountno);
                Current_user = m_session.User;
                
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Server unavailable", "Server unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            if (Current_user == "CONNECT_ERROR")
            {
                MessageBox.Show("Client number invalid", "Client number invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            if (Current_user != "CONNECT_ERROR" && Current_user != null)
            {
                LoginForm.ActiveForm.Hide();
                ShopperForm shopperForm = new ShopperForm(m_session, Current_user);
                shopperForm.Show();
            }

            

           
        }

        private void textBox_hostname_TextChanged(object sender, EventArgs e)
        {

            host = textBox_hostname.Text;
        }

        private void textBox_account_TextChanged(object sender, EventArgs e)
        {
            button_connect.Enabled = !string.IsNullOrEmpty(textBox_account.Text);
            accountno = textBox_account.Text;
        }
    }
}
