using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Alarm501_Library;

namespace Alarm501_GUI
{
    /// <summary>
    /// A view class used for displaying, adding, editng, and using <see cref="Alarm"/>s.
    /// </summary>
    public partial class View : Form
    {
        #region Fields
        /// <summary>
        /// The <see cref="AlarmListM"/> model the <see cref="View"/> gets its data from.
        /// </summary>
        private AlarmListM _model;

        /// <summary>
        /// The <see cref="AlarmDialog"/> to use.
        /// </summary>
        private AlarmDialog _dialog;

        /// <summary>
        /// The <see cref="Start"/> method to use when the program starts.
        /// </summary>
        private Start _start;

        /// <summary>
        /// the <see cref="End"/> method to use when the program ends.
        /// </summary>
        private End _end;

        /// <summary>
        /// The <see cref="AddAlarm"/> method to use when the add button is pressed.
        /// </summary>
        private AddAlarm _addAlarm;

        /// <summary>
        /// The <see cref="EditAlarm"/> method to use when the edit button is pressed.
        /// </summary>
        private EditAlarm _editAlarm;

        /// <summary>
        /// The <see cref="SelectionChanged"/> method to use when the selected <see cref="Alarm"/> changes.
        /// </summary>
        private SelectionChanged _selectionChanged;

        /// <summary>
        /// The <see cref="SnoozeAlarm"/> method to use when a user snoozes an <see cref="Alarm"/>.
        /// </summary>
        private SnoozeAlarm _snoozeAlarm;

        /// <summary>
        /// The <see cref="StopAlarm"/> method to use when a user Stops an <see cref="Alarm"/>.
        /// </summary>
        private StopAlarm _stopAlarm;

        /// <summary>
        /// The snooze <see cref="Timer"/> that has priority.
        /// </summary>
        private Timer _nextSnooze;
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="View"/> class.
        /// </summary>
        /// <param name="m">The <see cref="AlarmListM"/> model the <see cref="View"/> is using.</param>
        /// <param name="dialog">The <see cref="AlarmDialog"/> the <see cref="View"/> is using.</param>
        /// <param name="handle">The <see cref="HandleInput"/> method the <see cref="View"/> is using.</param>
        public View(AlarmListM m, AlarmDialog dialog)
        {
            InitializeComponent();
            _model = m;
            _dialog = dialog;
            uxAlarms.DataSource = _model.Alarms;
        }
        #endregion


        #region Event Handlers
        /// <summary>
        /// An event handler that notifies the controller when the edit button is pressed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditButton_Click(object sender, EventArgs e)
        {
            // store index upon click because if an alarm goes off during edit it will change the selected index
            int index = uxAlarms.SelectedIndex;
            _dialog.SetCurrentInfo(_model.Alarms[uxAlarms.SelectedIndex]);
            _dialog.ShowDialog();
            if (_dialog.DialogResult == DialogResult.OK) _editAlarm(index,_dialog.GetAlarm());
        }

        /// <summary>
        /// An event handler that notifies the controller when the add button is pressed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddButton_Click(object sender, EventArgs e)
        {
            _dialog.SetDefaultInfo();
            _dialog.ShowDialog();
            if (_dialog.DialogResult == DialogResult.OK) _addAlarm(_dialog.GetAlarm());
        }

        /// <summary>
        /// An event handler that notifies the controller when the stop button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStopButton_Click(object sender, EventArgs e) => _stopAlarm(uxAlarms.SelectedIndex);

        /// <summary>
        /// An event handler that notifies the controller when the snooze button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSnoozeButton_Click(object sender, EventArgs e) => _snoozeAlarm(uxAlarms.SelectedIndex);

        /// <summary>
        /// An event handler that notifies the controller when the selected index of the alarms change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAlarms_SelectedIndexChanged(object sender, EventArgs e) => _selectionChanged(uxAlarms.SelectedIndex);

        /// <summary>
        /// An event handler that notifies the controller when the <see cref="View"/> closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _end();
        }
        #endregion


        #region Methods
        /// <summary>
        /// Updates the controller when the <see cref="View"/> first opens.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e) => _start();
        
        public void toggleAddButton(bool OnOff) { uxAddButton.Invoke(new Action(() => uxAddButton.Enabled = OnOff)); }
        public void toggleEditButton(bool OnOff) { uxEditButton.Invoke(new Action(() => uxEditButton.Enabled = OnOff)); }
        public void toggleStopButton(bool OnOff) { uxStopButton.Invoke(new Action(() => uxStopButton.Enabled = OnOff)); }
        public void toggleSnoozeButton(bool OnOff) { uxSnoozeButton.Invoke(new Action(() => uxSnoozeButton.Enabled = OnOff)); }
        public void updateUIMessage(string newMessage) { uxStatus.Invoke(new Action(() => uxStatus.Text = newMessage)); }
        public void setAlarmSelection(int index, string alarmMsg)
        {
            uxAlarms.Invoke(new Action(() => uxAlarms.SelectedIndex = index));
            updateUIMessage(alarmMsg);
        }
        #endregion


        #region Register Methods
        /// <summary>
        /// Registers the <see cref="Start"/> method.
        /// </summary>
        /// <param name="start">The <see cref="Start"/> method.</param>
        public void RegisterStart(Start start) => _start = start;

        /// <summary>
        /// Registers the <see cref="End"/> method.
        /// </summary>
        /// <param name="end">The <see cref="End"/> method.</param>
        public void RegisterEnd(End end) => _end = end;

        /// <summary>
        /// Registers the <see cref="AddAlarm"/> method.
        /// </summary>
        /// <param name="addAlarm">The <see cref="AddAlarm"/> method.</param>
        public void RegisterAddAlarm(AddAlarm addAlarm) => _addAlarm = addAlarm;

        /// <summary>
        /// Registers the <see cref="EditAlarm"/> method.
        /// </summary>
        /// <param name="editAlarm">The <see cref="EditAlarm"/> method.</param>
        public void RegisterEditAlarm(EditAlarm editAlarm) => _editAlarm = editAlarm;

        /// <summary>
        /// Registers the <see cref="SelectionChanged"/> method.
        /// </summary>
        /// <param name="selectionChanged">The <see cref="SelectionChanged"/> method.</param>
        public void RegisterSelectionChanged(SelectionChanged selectionChanged) => _selectionChanged = selectionChanged;

        /// <summary>
        /// Registers the <see cref="StopAlarm"/> method.
        /// </summary>
        /// <param name="stopAlarm">The <see cref="StopAlarm"/> method.</param>
        public void RegisterStopAlarm(StopAlarm stopAlarm) => _stopAlarm = stopAlarm;

        /// <summary>
        /// Registers the <see cref="SnoozeAlarm"/> method.
        /// </summary>
        /// <param name="snoozeAlarm">The <see cref="SnoozeAlarm"/> method.</param>
        public void RegisterSnoozeAlarm(SnoozeAlarm snoozeAlarm) => _snoozeAlarm = snoozeAlarm;
        #endregion

    }
}
