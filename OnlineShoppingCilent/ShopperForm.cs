using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace OnlineShoppingCilent
{
    public partial class ShopperForm : Form
    {
        string user_Protocol, username, comboBox, purchase_result;
        string[] name, products, orders_purchased;
        
        private readonly IShopperdata m_session;
        public ShopperForm(IShopperdata session, string user)
        {
            InitializeComponent();
            m_session = session;
            user_Protocol = user;
        }

        private void comboBox_products_TextChanged(object sender, EventArgs e)
        {
            button_Purchase.Enabled = !string.IsNullOrEmpty(comboBox_products.Text);
        }

        private async void ShopperForm_Load(object sender, EventArgs e)
        {
            button_Purchase.Enabled = false;
            name = user_Protocol.Split(':');
            username = name[1];
            this.Text = $"ShopCilent, User {username}";
            try
            {
                await m_session.GEt_Products();
                products = m_session.Stock_Products;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            foreach (var prop in products)
            {
                comboBox_products.Items.Add(prop);
            }

            try
            {
                await m_session.Get_Order();
                orders_purchased = m_session.orders_purchased;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            foreach (var or in orders_purchased)
            {
                TextBox_ShopperDisplay.AppendText(or);
                TextBox_ShopperDisplay.AppendText(Environment.NewLine);
            }
        }

        private async void button_Refresh_Click(object sender, EventArgs e)
        {
            
            try
            {
                await m_session.Get_Order();
                orders_purchased = m_session.orders_purchased;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            TextBox_ShopperDisplay.Text = string.Empty;
            foreach (var or in orders_purchased)
            {
                TextBox_ShopperDisplay.AppendText(or);
                TextBox_ShopperDisplay.AppendText(Environment.NewLine);
            }
        }

        private async void button_Purchase_Click(object sender, EventArgs e)
        {
            comboBox = comboBox_products.Text;
            try
            {
                await m_session.Purchase(comboBox);
                purchase_result = m_session.purchase_result;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            if (purchase_result == "NOT_VALID")
            {
                MessageBox.Show("This specified product is not vaild", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (purchase_result == "NOT_AVAILABLE")
            {
                MessageBox.Show("This product is not available", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (purchase_result == "DONE")
            {
                try
                {
                    await m_session.Get_Order();
                    orders_purchased = m_session.orders_purchased;
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                TextBox_ShopperDisplay.Text = string.Empty;
                foreach (var or in orders_purchased)
                {
                    TextBox_ShopperDisplay.AppendText(or);
                    TextBox_ShopperDisplay.AppendText(Environment.NewLine);
                }
            }
        }

        private void ShopperForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_session.Disconnect();
            Application.Exit();
        }



    }
}
