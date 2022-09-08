
namespace Bid501_Server
{
    partial class AddProductForm
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
            this.uxProducts = new System.Windows.Forms.ListBox();
            this.uxAddBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxProducts
            // 
            this.uxProducts.FormattingEnabled = true;
            this.uxProducts.Location = new System.Drawing.Point(14, 15);
            this.uxProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxProducts.Name = "uxProducts";
            this.uxProducts.Size = new System.Drawing.Size(181, 277);
            this.uxProducts.TabIndex = 0;
            // 
            // uxAddBtn
            // 
            this.uxAddBtn.Location = new System.Drawing.Point(64, 302);
            this.uxAddBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxAddBtn.Name = "uxAddBtn";
            this.uxAddBtn.Size = new System.Drawing.Size(75, 41);
            this.uxAddBtn.TabIndex = 1;
            this.uxAddBtn.Text = "Add Next";
            this.uxAddBtn.UseVisualStyleBackColor = true;
            this.uxAddBtn.Click += new System.EventHandler(this.uxAddBtn_Click);
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 352);
            this.Controls.Add(this.uxAddBtn);
            this.Controls.Add(this.uxProducts);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddProductForm";
            this.Text = "AddProductForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox uxProducts;
        private System.Windows.Forms.Button uxAddBtn;
    }
}