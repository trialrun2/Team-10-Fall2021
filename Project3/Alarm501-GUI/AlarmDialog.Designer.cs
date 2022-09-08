
namespace Alarm501_GUI
{
    partial class AlarmDialog
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
            this.uxAlarmTime = new System.Windows.Forms.DateTimePicker();
            this.uxAlarmSound = new System.Windows.Forms.ComboBox();
            this.uxSnoozeTime = new System.Windows.Forms.NumericUpDown();
            this.uxEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uxCancelButton = new System.Windows.Forms.Button();
            this.uxSetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxSnoozeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // uxAlarmTime
            // 
            this.uxAlarmTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uxAlarmTime.Location = new System.Drawing.Point(9, 10);
            this.uxAlarmTime.Margin = new System.Windows.Forms.Padding(2);
            this.uxAlarmTime.Name = "uxAlarmTime";
            this.uxAlarmTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uxAlarmTime.ShowUpDown = true;
            this.uxAlarmTime.Size = new System.Drawing.Size(103, 20);
            this.uxAlarmTime.TabIndex = 0;
            // 
            // uxAlarmSound
            // 
            this.uxAlarmSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxAlarmSound.FormattingEnabled = true;
            this.uxAlarmSound.Location = new System.Drawing.Point(9, 78);
            this.uxAlarmSound.Margin = new System.Windows.Forms.Padding(2);
            this.uxAlarmSound.Name = "uxAlarmSound";
            this.uxAlarmSound.Size = new System.Drawing.Size(103, 21);
            this.uxAlarmSound.TabIndex = 1;
            // 
            // uxSnoozeTime
            // 
            this.uxSnoozeTime.Location = new System.Drawing.Point(9, 45);
            this.uxSnoozeTime.Margin = new System.Windows.Forms.Padding(2);
            this.uxSnoozeTime.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.uxSnoozeTime.Name = "uxSnoozeTime";
            this.uxSnoozeTime.Size = new System.Drawing.Size(102, 20);
            this.uxSnoozeTime.TabIndex = 3;
            // 
            // uxEnabled
            // 
            this.uxEnabled.AutoSize = true;
            this.uxEnabled.Checked = true;
            this.uxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uxEnabled.Location = new System.Drawing.Point(65, 114);
            this.uxEnabled.Margin = new System.Windows.Forms.Padding(2);
            this.uxEnabled.Name = "uxEnabled";
            this.uxEnabled.Size = new System.Drawing.Size(110, 19);
            this.uxEnabled.TabIndex = 4;
            this.uxEnabled.Text = "Alarm Enabled";
            this.uxEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alarm Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Snooze Time (min)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Alarm Sound";
            // 
            // uxCancelButton
            // 
            this.uxCancelButton.Location = new System.Drawing.Point(9, 142);
            this.uxCancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.uxCancelButton.Name = "uxCancelButton";
            this.uxCancelButton.Size = new System.Drawing.Size(93, 25);
            this.uxCancelButton.TabIndex = 8;
            this.uxCancelButton.Text = "Cancel";
            this.uxCancelButton.UseVisualStyleBackColor = true;
            this.uxCancelButton.Click += new System.EventHandler(this.uxCancelButton_Click);
            // 
            // uxSetButton
            // 
            this.uxSetButton.Location = new System.Drawing.Point(116, 142);
            this.uxSetButton.Margin = new System.Windows.Forms.Padding(2);
            this.uxSetButton.Name = "uxSetButton";
            this.uxSetButton.Size = new System.Drawing.Size(93, 25);
            this.uxSetButton.TabIndex = 9;
            this.uxSetButton.Text = "Set";
            this.uxSetButton.UseVisualStyleBackColor = true;
            this.uxSetButton.Click += new System.EventHandler(this.uxSetButton_Click);
            // 
            // AlarmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 171);
            this.Controls.Add(this.uxSetButton);
            this.Controls.Add(this.uxCancelButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxEnabled);
            this.Controls.Add(this.uxSnoozeTime);
            this.Controls.Add(this.uxAlarmSound);
            this.Controls.Add(this.uxAlarmTime);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AlarmDialog";
            this.Text = "AlarmDialog";
            ((System.ComponentModel.ISupportInitialize)(this.uxSnoozeTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker uxAlarmTime;
        private System.Windows.Forms.ComboBox uxAlarmSound;
        private System.Windows.Forms.NumericUpDown uxSnoozeTime;
        private System.Windows.Forms.CheckBox uxEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button uxCancelButton;
        private System.Windows.Forms.Button uxSetButton;
    }
}