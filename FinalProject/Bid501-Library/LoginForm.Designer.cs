
namespace Bid501_Library
{
    partial class LoginForm
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
            this.uxUsernameLabel = new System.Windows.Forms.Label();
            this.uxPasswordLabel = new System.Windows.Forms.Label();
            this.uxUsername = new System.Windows.Forms.TextBox();
            this.uxPassword = new System.Windows.Forms.TextBox();
            this.uxLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxUsernameLabel
            // 
            this.uxUsernameLabel.AutoSize = true;
            this.uxUsernameLabel.Location = new System.Drawing.Point(12, 15);
            this.uxUsernameLabel.Name = "uxUsernameLabel";
            this.uxUsernameLabel.Size = new System.Drawing.Size(77, 17);
            this.uxUsernameLabel.TabIndex = 0;
            this.uxUsernameLabel.Text = "Username:";
            // 
            // uxPasswordLabel
            // 
            this.uxPasswordLabel.AutoSize = true;
            this.uxPasswordLabel.Location = new System.Drawing.Point(12, 43);
            this.uxPasswordLabel.Name = "uxPasswordLabel";
            this.uxPasswordLabel.Size = new System.Drawing.Size(73, 17);
            this.uxPasswordLabel.TabIndex = 1;
            this.uxPasswordLabel.Text = "Password:";
            // 
            // uxUsername
            // 
            this.uxUsername.Location = new System.Drawing.Point(91, 12);
            this.uxUsername.Name = "uxUsername";
            this.uxUsername.Size = new System.Drawing.Size(206, 22);
            this.uxUsername.TabIndex = 2;
            this.uxUsername.TextChanged += new System.EventHandler(this.uxUsername_TextChanged);
            // 
            // uxPassword
            // 
            this.uxPassword.Enabled = false;
            this.uxPassword.Location = new System.Drawing.Point(91, 40);
            this.uxPassword.Name = "uxPassword";
            this.uxPassword.Size = new System.Drawing.Size(206, 22);
            this.uxPassword.TabIndex = 3;
            this.uxPassword.TextChanged += new System.EventHandler(this.uxPassword_TextChanged);
            // 
            // uxLoginButton
            // 
            this.uxLoginButton.Enabled = false;
            this.uxLoginButton.Location = new System.Drawing.Point(207, 68);
            this.uxLoginButton.Name = "uxLoginButton";
            this.uxLoginButton.Size = new System.Drawing.Size(90, 32);
            this.uxLoginButton.TabIndex = 4;
            this.uxLoginButton.Text = "Login";
            this.uxLoginButton.UseVisualStyleBackColor = true;
            this.uxLoginButton.Click += new System.EventHandler(this.uxLoginButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 115);
            this.Controls.Add(this.uxLoginButton);
            this.Controls.Add(this.uxPassword);
            this.Controls.Add(this.uxUsername);
            this.Controls.Add(this.uxPasswordLabel);
            this.Controls.Add(this.uxUsernameLabel);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxUsernameLabel;
        private System.Windows.Forms.Label uxPasswordLabel;
        private System.Windows.Forms.TextBox uxUsername;
        private System.Windows.Forms.TextBox uxPassword;
        private System.Windows.Forms.Button uxLoginButton;
    }
}