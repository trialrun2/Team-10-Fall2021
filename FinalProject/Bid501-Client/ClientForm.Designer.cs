namespace Bid501_Client
{
    partial class ClientForm
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
            this.uxProductLabel = new System.Windows.Forms.Label();
            this.uxProductList = new System.Windows.Forms.ListBox();
            this.uxSelectedProductLabel = new System.Windows.Forms.Label();
            this.uxStatusLabel = new System.Windows.Forms.Label();
            this.uxBidTextBox = new System.Windows.Forms.TextBox();
            this.uxBidCount = new System.Windows.Forms.Label();
            this.uxMinimumBid = new System.Windows.Forms.Label();
            this.uxBidButton = new System.Windows.Forms.Button();
            this.uxUserIDBox = new System.Windows.Forms.Label();
            this.uxStatus = new System.Windows.Forms.Label();
            this.uxMinimumBidLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxProductLabel
            // 
            this.uxProductLabel.AutoSize = true;
            this.uxProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxProductLabel.Location = new System.Drawing.Point(319, 11);
            this.uxProductLabel.Name = "uxProductLabel";
            this.uxProductLabel.Size = new System.Drawing.Size(76, 20);
            this.uxProductLabel.TabIndex = 0;
            this.uxProductLabel.Text = "Products";
            // 
            // uxProductList
            // 
            this.uxProductList.FormattingEnabled = true;
            this.uxProductList.ItemHeight = 16;
            this.uxProductList.Location = new System.Drawing.Point(253, 33);
            this.uxProductList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxProductList.Name = "uxProductList";
            this.uxProductList.Size = new System.Drawing.Size(224, 244);
            this.uxProductList.TabIndex = 1;
            this.uxProductList.SelectedIndexChanged += new System.EventHandler(this.uxProduct_SelectionChanged);
            // 
            // uxSelectedProductLabel
            // 
            this.uxSelectedProductLabel.AutoSize = true;
            this.uxSelectedProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.uxSelectedProductLabel.Location = new System.Drawing.Point(27, 74);
            this.uxSelectedProductLabel.Name = "uxSelectedProductLabel";
            this.uxSelectedProductLabel.Size = new System.Drawing.Size(124, 17);
            this.uxSelectedProductLabel.TabIndex = 2;
            this.uxSelectedProductLabel.Text = "[Selected Product]";
            // 
            // uxStatusLabel
            // 
            this.uxStatusLabel.AutoSize = true;
            this.uxStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.uxStatusLabel.Location = new System.Drawing.Point(27, 113);
            this.uxStatusLabel.Name = "uxStatusLabel";
            this.uxStatusLabel.Size = new System.Drawing.Size(56, 17);
            this.uxStatusLabel.TabIndex = 3;
            this.uxStatusLabel.Text = "Status: ";
            // 
            // uxBidTextBox
            // 
            this.uxBidTextBox.Location = new System.Drawing.Point(47, 154);
            this.uxBidTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxBidTextBox.Name = "uxBidTextBox";
            this.uxBidTextBox.Size = new System.Drawing.Size(71, 22);
            this.uxBidTextBox.TabIndex = 4;
            // 
            // uxBidCount
            // 
            this.uxBidCount.AutoSize = true;
            this.uxBidCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.uxBidCount.Location = new System.Drawing.Point(123, 158);
            this.uxBidCount.Name = "uxBidCount";
            this.uxBidCount.Size = new System.Drawing.Size(74, 17);
            this.uxBidCount.TabIndex = 5;
            this.uxBidCount.Text = "[bid count]";
            // 
            // uxMinimumBid
            // 
            this.uxMinimumBid.AutoSize = true;
            this.uxMinimumBid.Location = new System.Drawing.Point(123, 196);
            this.uxMinimumBid.Name = "uxMinimumBid";
            this.uxMinimumBid.Size = new System.Drawing.Size(94, 17);
            this.uxMinimumBid.TabIndex = 6;
            this.uxMinimumBid.Text = "[minimum bid]";
            // 
            // uxBidButton
            // 
            this.uxBidButton.Location = new System.Drawing.Point(69, 238);
            this.uxBidButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxBidButton.Name = "uxBidButton";
            this.uxBidButton.Size = new System.Drawing.Size(99, 39);
            this.uxBidButton.TabIndex = 7;
            this.uxBidButton.Text = "Place Bid";
            this.uxBidButton.UseVisualStyleBackColor = true;
            this.uxBidButton.Click += new System.EventHandler(this.uxBidButton_Click);
            // 
            // uxUserIDBox
            // 
            this.uxUserIDBox.AutoSize = true;
            this.uxUserIDBox.Location = new System.Drawing.Point(27, 33);
            this.uxUserIDBox.Name = "uxUserIDBox";
            this.uxUserIDBox.Size = new System.Drawing.Size(61, 17);
            this.uxUserIDBox.TabIndex = 8;
            this.uxUserIDBox.Text = "[user ID]";
            // 
            // uxStatus
            // 
            this.uxStatus.AutoSize = true;
            this.uxStatus.Location = new System.Drawing.Point(80, 113);
            this.uxStatus.Name = "uxStatus";
            this.uxStatus.Size = new System.Drawing.Size(56, 17);
            this.uxStatus.TabIndex = 9;
            this.uxStatus.Text = "[Status]";
            // 
            // uxMinimumBidLabel
            // 
            this.uxMinimumBidLabel.AutoSize = true;
            this.uxMinimumBidLabel.Location = new System.Drawing.Point(27, 196);
            this.uxMinimumBidLabel.Name = "uxMinimumBidLabel";
            this.uxMinimumBidLabel.Size = new System.Drawing.Size(91, 17);
            this.uxMinimumBidLabel.TabIndex = 10;
            this.uxMinimumBidLabel.Text = "Minimum Bid:";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 288);
            this.Controls.Add(this.uxMinimumBidLabel);
            this.Controls.Add(this.uxStatus);
            this.Controls.Add(this.uxUserIDBox);
            this.Controls.Add(this.uxBidButton);
            this.Controls.Add(this.uxMinimumBid);
            this.Controls.Add(this.uxBidCount);
            this.Controls.Add(this.uxBidTextBox);
            this.Controls.Add(this.uxStatusLabel);
            this.Controls.Add(this.uxSelectedProductLabel);
            this.Controls.Add(this.uxProductList);
            this.Controls.Add(this.uxProductLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxProductLabel;
        private System.Windows.Forms.ListBox uxProductList;
        private System.Windows.Forms.Label uxSelectedProductLabel;
        private System.Windows.Forms.Label uxStatusLabel;
        private System.Windows.Forms.TextBox uxBidTextBox;
        private System.Windows.Forms.Label uxBidCount;
        private System.Windows.Forms.Label uxMinimumBid;
        private System.Windows.Forms.Button uxBidButton;
        private System.Windows.Forms.Label uxUserIDBox;
        private System.Windows.Forms.Label uxStatus;
        private System.Windows.Forms.Label uxMinimumBidLabel;
    }
}