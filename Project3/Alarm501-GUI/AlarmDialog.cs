using System;
using System.Windows.Forms;
using Alarm501_Library;

namespace Alarm501_GUI
{
    /// <summary>
    /// A dialog used for creating <see cref="Alarm"/>s.
    /// </summary>
    public partial class AlarmDialog : Form
    {
        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="AlarmDialog"/> class.
        /// </summary>
        public AlarmDialog()
        {
            InitializeComponent();
            uxAlarmSound.Items.AddRange(Enum.GetNames(typeof(AlarmSound)));
            uxAlarmSound.SelectedIndex = 0;
        }
        #endregion


        #region Event Handlers
        /// <summary>
        /// An event handler for when the cancel button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// An event handler for when the set button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSetButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion


        #region Methods
        /// <summary>
        /// Gets the <see cref="Alarm"/> that contains the information from the dialog.
        /// </summary>
        /// <returns>The <see cref="Alarm"/> from the dialog.</returns>
        public Alarm GetAlarm() => new Alarm(uxAlarmTime.Value, (int)uxSnoozeTime.Value, (AlarmSound)uxAlarmSound.SelectedIndex, uxEnabled.Checked);

        /// <summary>
        /// Sets the info in the dialog to a passed <see cref="Alarm"/>.
        /// </summary>
        /// <param name="alarm">The <see cref="Alarm"/> with the desired information.</param>
        public void SetCurrentInfo(Alarm alarm)
        {
            uxAlarmTime.Value = alarm.Time;
            uxSnoozeTime.Value = alarm.SnoozeTime;
            uxAlarmSound.SelectedItem = alarm.Sound.ToString();
            uxEnabled.Checked = alarm.Enabled;
        }

        /// <summary>
        /// Sets the default info in the dialog.
        /// </summary>
        public void SetDefaultInfo()
        {
            uxAlarmTime.Value = DateTime.Now;
            uxSnoozeTime.Value = 0;
            uxAlarmSound.SelectedItem = AlarmSound.Radar.ToString();
            uxEnabled.Checked = true;
        }
        #endregion

    }
}
