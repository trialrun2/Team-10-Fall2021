
namespace Alarm501_GUI
{
    partial class View
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
            this.uxAddButton = new System.Windows.Forms.Button();
            this.uxEditButton = new System.Windows.Forms.Button();
            this.uxAlarms = new System.Windows.Forms.ListBox();
            this.uxSnoozeButton = new System.Windows.Forms.Button();
            this.uxStopButton = new System.Windows.Forms.Button();
            this.uxStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxAddButton
            // 
            this.uxAddButton.Location = new System.Drawing.Point(37, 15);
            this.uxAddButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxAddButton.Name = "uxAddButton";
            this.uxAddButton.Size = new System.Drawing.Size(73, 26);
            this.uxAddButton.TabIndex = 0;
            this.uxAddButton.Text = "ADD";
            this.uxAddButton.UseVisualStyleBackColor = true;
            this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
            // 
            // uxEditButton
            // 
            this.uxEditButton.Location = new System.Drawing.Point(114, 15);
            this.uxEditButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxEditButton.Name = "uxEditButton";
            this.uxEditButton.Size = new System.Drawing.Size(73, 26);
            this.uxEditButton.TabIndex = 1;
            this.uxEditButton.Text = "EDIT";
            this.uxEditButton.UseVisualStyleBackColor = true;
            this.uxEditButton.Click += new System.EventHandler(this.uxEditButton_Click);
            // 
            // uxAlarms
            // 
            this.uxAlarms.FormattingEnabled = true;
            this.uxAlarms.Location = new System.Drawing.Point(37, 46);
            this.uxAlarms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxAlarms.Name = "uxAlarms";
            this.uxAlarms.Size = new System.Drawing.Size(151, 173);
            this.uxAlarms.TabIndex = 2;
            this.uxAlarms.SelectedIndexChanged += new System.EventHandler(this.uxAlarms_SelectedIndexChanged);
            // 
            // uxSnoozeButton
            // 
            this.uxSnoozeButton.Location = new System.Drawing.Point(37, 260);
            this.uxSnoozeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxSnoozeButton.Name = "uxSnoozeButton";
            this.uxSnoozeButton.Size = new System.Drawing.Size(73, 26);
            this.uxSnoozeButton.TabIndex = 3;
            this.uxSnoozeButton.Text = "SNOOZE";
            this.uxSnoozeButton.UseVisualStyleBackColor = true;
            this.uxSnoozeButton.Click += new System.EventHandler(this.uxSnoozeButton_Click);
            // 
            // uxStopButton
            // 
            this.uxStopButton.Location = new System.Drawing.Point(114, 260);
            this.uxStopButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxStopButton.Name = "uxStopButton";
            this.uxStopButton.Size = new System.Drawing.Size(73, 26);
            this.uxStopButton.TabIndex = 4;
            this.uxStopButton.Text = "STOP";
            this.uxStopButton.UseVisualStyleBackColor = true;
            this.uxStopButton.Click += new System.EventHandler(this.uxStopButton_Click);
            // 
            // uxStatus
            // 
            this.uxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxStatus.Location = new System.Drawing.Point(0, 0);
            this.uxStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxStatus.Name = "uxStatus";
            this.uxStatus.Size = new System.Drawing.Size(150, 33);
            this.uxStatus.TabIndex = 5;
            this.uxStatus.Text = "label1";
            this.uxStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uxStatus);
            this.panel1.Location = new System.Drawing.Point(35, 223);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 33);
            this.panel1.TabIndex = 6;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 304);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uxStopButton);
            this.Controls.Add(this.uxSnoozeButton);
            this.Controls.Add(this.uxAlarms);
            this.Controls.Add(this.uxEditButton);
            this.Controls.Add(this.uxAddButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "View";
            this.Text = "Alarm501";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxAddButton;
        private System.Windows.Forms.Button uxEditButton;
        private System.Windows.Forms.ListBox uxAlarms;
        private System.Windows.Forms.Button uxSnoozeButton;
        private System.Windows.Forms.Button uxStopButton;
        private System.Windows.Forms.Label uxStatus;
        private System.Windows.Forms.Panel panel1;
    }
}

