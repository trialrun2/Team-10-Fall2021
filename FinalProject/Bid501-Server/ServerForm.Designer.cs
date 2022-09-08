
namespace Bid501_Server
{
    partial class ServerForm
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
            this.uxAddbtn = new System.Windows.Forms.Button();
            this.uxProducts = new System.Windows.Forms.ListBox();
            this.uxClients = new System.Windows.Forms.ListBox();
            this.uxEndBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxAddbtn
            // 
            this.uxAddbtn.Location = new System.Drawing.Point(150, 370);
            this.uxAddbtn.Name = "uxAddbtn";
            this.uxAddbtn.Size = new System.Drawing.Size(100, 50);
            this.uxAddbtn.TabIndex = 0;
            this.uxAddbtn.Text = "Add";
            this.uxAddbtn.UseVisualStyleBackColor = true;
            this.uxAddbtn.Click += new System.EventHandler(this.uxAddbtn_Click);
            // 
            // uxProducts
            // 
            this.uxProducts.FormattingEnabled = true;
            this.uxProducts.ItemHeight = 16;
            this.uxProducts.Location = new System.Drawing.Point(15, 15);
            this.uxProducts.Name = "uxProducts";
            this.uxProducts.Size = new System.Drawing.Size(240, 340);
            this.uxProducts.TabIndex = 1;
            // 
            // uxClients
            // 
            this.uxClients.FormattingEnabled = true;
            this.uxClients.ItemHeight = 16;
            this.uxClients.Location = new System.Drawing.Point(275, 15);
            this.uxClients.Name = "uxClients";
            this.uxClients.Size = new System.Drawing.Size(240, 340);
            this.uxClients.TabIndex = 2;
            // 
            // uxEndBtn
            // 
            this.uxEndBtn.Location = new System.Drawing.Point(275, 370);
            this.uxEndBtn.Name = "uxEndBtn";
            this.uxEndBtn.Size = new System.Drawing.Size(100, 50);
            this.uxEndBtn.TabIndex = 3;
            this.uxEndBtn.Text = "End";
            this.uxEndBtn.UseVisualStyleBackColor = true;
            this.uxEndBtn.Click += new System.EventHandler(this.uxEndBtn_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 433);
            this.Controls.Add(this.uxEndBtn);
            this.Controls.Add(this.uxClients);
            this.Controls.Add(this.uxProducts);
            this.Controls.Add(this.uxAddbtn);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxAddbtn;
        private System.Windows.Forms.ListBox uxProducts;
        private System.Windows.Forms.ListBox uxClients;
        private System.Windows.Forms.Button uxEndBtn;
    }
}

