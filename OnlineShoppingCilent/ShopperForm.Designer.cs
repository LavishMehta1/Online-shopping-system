
namespace OnlineShoppingCilent
{
    partial class ShopperForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox_products = new System.Windows.Forms.ComboBox();
            this.TextBox_ShopperDisplay = new System.Windows.Forms.TextBox();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_Purchase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_products
            // 
            this.comboBox_products.FormattingEnabled = true;
            this.comboBox_products.Location = new System.Drawing.Point(233, 21);
            this.comboBox_products.Name = "comboBox_products";
            this.comboBox_products.Size = new System.Drawing.Size(121, 21);
            this.comboBox_products.TabIndex = 6;
            this.comboBox_products.TextChanged += new System.EventHandler(this.comboBox_products_TextChanged);
            // 
            // TextBox_ShopperDisplay
            // 
            this.TextBox_ShopperDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.TextBox_ShopperDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_ShopperDisplay.Location = new System.Drawing.Point(1, 21);
            this.TextBox_ShopperDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_ShopperDisplay.Multiline = true;
            this.TextBox_ShopperDisplay.Name = "TextBox_ShopperDisplay";
            this.TextBox_ShopperDisplay.ReadOnly = true;
            this.TextBox_ShopperDisplay.Size = new System.Drawing.Size(223, 322);
            this.TextBox_ShopperDisplay.TabIndex = 11;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(259, 220);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(95, 45);
            this.button_Refresh.TabIndex = 12;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // button_Purchase
            // 
            this.button_Purchase.Location = new System.Drawing.Point(259, 298);
            this.button_Purchase.Name = "button_Purchase";
            this.button_Purchase.Size = new System.Drawing.Size(95, 45);
            this.button_Purchase.TabIndex = 13;
            this.button_Purchase.Text = "Purchase";
            this.button_Purchase.UseVisualStyleBackColor = true;
            this.button_Purchase.Click += new System.EventHandler(this.button_Purchase_Click);
            // 
            // ShopperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 370);
            this.Controls.Add(this.button_Purchase);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.TextBox_ShopperDisplay);
            this.Controls.Add(this.comboBox_products);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(403, 409);
            this.MinimumSize = new System.Drawing.Size(403, 409);
            this.Name = "ShopperForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShopperForm_FormClosed);
            this.Load += new System.EventHandler(this.ShopperForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox_products;
        private System.Windows.Forms.TextBox TextBox_ShopperDisplay;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_Purchase;
    }
}