using System;

namespace Alarm501_Library
{
    /// <summary>
    /// A class that controlls the flow of the program.
    /// </summary>
    public class Controller
    {
        #region Fields
        /// <summary>
        /// The model that this controller uses.
        /// </summary>
        private AlarmListM _model;

        /// <summary>
        /// The <see cref="Delegate"/> method that saves the <see cref="Alarm"/>s to a file.
        /// </summary>
        private SaveFile _saveFile;

        /// <summary>
        /// The <see cref="Delegate"/> method that loads the <see cref="Alarm"/>s from a file.
        /// </summary>
        private LoadFile _loadFile;

        /// <summary>
        /// The <see cref="Delegate"/> method for updating the UI message.
        /// </summary>
        private UpdateUIMessage _updateUIMessage;

        /// <summary>
        /// The <see cref="Delegate"/> method that sets the current alarm selection
        /// in the list of alarms.
        /// </summary>
        private SetAlarmSelection _setAlarmSelection;

        /// <summary>
        /// The <see cref="Delegate"/> method that toggles the availability of the
        /// Add Alarm functionality.
        /// </summary>
        private ToggleAddAlarm _toggleAddAlarm;

        /// <summary>
        /// The <see cref="Delegate"/> method that toggles the availability of the
        /// Edit Alarm functionality.
        /// </summary>
        private ToggleEditAlarm _toggleEditAlarm;

        /// <summary>
        /// The <see cref="Delegate"/> that toggles the availability of the
        /// Snooze Alarm functionality.
        /// </summary>
        private ToggleSnoozeAlarm _toggleSnoozeAlarm;

        /// <summary>
        /// The <see cref="Delegate"/> that toggles the availability of the
        /// Stop Alarm functionality.
        /// </summary>
        private ToggleStopAlarm _toggleStopAlarm;

        /// <summary>
        /// The <see cref="Delegate"/> method that updates all the <see cref="AlarmTimer"/>s.
        /// </summary>
        private UpdateTimers _updateTimers;

        /// <summary>
        /// The <see cref="Delegate"/> method that snoozes an <see cref="AlarmTimer"/>.
        /// </summary>
        private Snooze _snooze;

        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="m">The <see cref="AlarmListM"/> to use as the model.</param>
        /// <param name="save">The <see cref="SaveFile"/> method to use for saving.</param>
        /// <param name="load">The <see cref="LoadFile"/> method to use for loading.</param>
        public Controller(AlarmListM m, SaveFile save, LoadFile load)
        {
            _model = m;
            _saveFile = save;
            _loadFile = load;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Loads a file.
        /// </summary>
        public void Start()
        {
            _loadFile();
            _updateTimers();
            _toggleStopAlarm(false);
            _toggleSnoozeAlarm(false);
            _updateUIMessage("");
            // There's probably a way to make this if-statement more concise.
            if (_model.Alarms.Count < 1) _toggleEditAlarm(false);
            else if (_model.Alarms.Count >= 1 && _model.Alarms.Count < 5)
            {
                _setAlarmSelection(0, _model.Alarms[0].AlarmStatusMessage);
                if (_model.Alarms[0].InAlarm) { _toggleSnoozeAlarm(true); _toggleStopAlarm(true); }
            }
            else {
                _toggleAddAlarm(false);
                _setAlarmSelection(0, _model.Alarms[0].AlarmStatusMessage);
                if (_model.Alarms[0].InAlarm) { _toggleSnoozeAlarm(true); _toggleStopAlarm(true); }
            }
        }

        /// <summary>
        /// Saves a file.
        /// </summary>
        public void End()
        {
            foreach (Alarm alarm in _model.Alarms)
            {
                alarm.AlarmStatusMessage = alarm.Enabled ? "Running." : "Off.";
                alarm.InAlarm = false;
            }
            _updateTimers();
            _saveFile();
        }

        /// <summary>
        /// Adds and sets a new <see cref="Alarm"/>.
        /// </summary>
        /// <param name="alarm">The <see cref="Alarm"/> to add.</param>
        public void AddAlarm(Alarm alarm)
        {
            _model.AddAlarm(alarm);
            _updateTimers();
            if (_model.Alarms.Count >= 5) _toggleAddAlarm(false);
            _toggleEditAlarm(true);
            int index = _model.Alarms.Count - 1;
            _setAlarmSelection(index, _model.Alarms[index].AlarmStatusMessage);
        }

        /// <summary>
        /// Edits an existing <see cref="Alarm"/>.
        /// </summary>
        /// <param name="index">The index for the <see cref="Alarm"/>.</param>
        /// <param name="alarm">The <see cref="Alarm"/> to edit.</param>
        public void EditAlarm(int index, Alarm alarm)
        {
            _model.EditAlarm(index, alarm);
            _updateTimers();
            _setAlarmSelection(index, _model.Alarms[index].AlarmStatusMessage);
        }

        /// <summary>
        /// Stops an <see cref="Alarm"/> from going off.
        /// </summary>
        public void StopAlarm(int index)
        {
            string stopMsg = $"Alarm {index + 1} stopped.";
            _model.Alarms[index].InAlarm = false;
            _model.Alarms[index].AlarmStatusMessage = stopMsg;
            _updateUIMessage(stopMsg);
            _toggleStopAlarm(false);
            _toggleSnoozeAlarm(false);
        }

        /// <summary>
        /// Snoozes an <see cref="Alarm"/> from going off.
        /// </summary>
        public void SnoozeAlarm(int index)
        {
            string snoozeMsg = $"Alarm {index + 1} snoozed.";
            _model.Alarms[index].InAlarm = false;
            _model.Alarms[index].AlarmStatusMessage = snoozeMsg;
            _updateUIMessage(snoozeMsg);
            _snooze(index);
            _updateUIMessage("Alarm Snoozed");
            _toggleStopAlarm(false);
            _toggleSnoozeAlarm(false);
        }

        /// <summary>
        /// Enables the edit button when a selection is changed.
        /// </summary>
        public void SelectionChanged(int index)
        {
            if (index >= 0)
            {
                _toggleEditAlarm(true);
                _updateUIMessage(_model.Alarms[index].AlarmStatusMessage);
                _toggleSnoozeAlarm(false);
                _toggleStopAlarm(false);
                if (_model.Alarms[index].InAlarm)
                {
                    _toggleSnoozeAlarm(true);
                    _toggleStopAlarm(true);
                }
            }
        }

        /// <summary>
        /// Is triggered when ever a snooze <see cref="Alarm"/> has elapsed.
        /// </summary>
        /// <param name="index">The index of the <see cref="Alarm"/>.</param>
        public void SnoozeAlarmElapsed(int index) 
        {
            string inAlarmMsg = $"Alarm {index + 1} went OFF | {_model.Alarms[index].Sound}";
            _model.Alarms[index].AlarmStatusMessage = inAlarmMsg;
            _model.Alarms[index].InAlarm = true;
            _setAlarmSelection(index, inAlarmMsg);
            _toggleSnoozeAlarm(true);
            _toggleStopAlarm(true);
        }

        /// <summary>
        /// Is triggered whenever an <see cref="Alarm"/> has elapsed.
        /// </summary>
        /// <param name="index">The index of the <see cref="Alarm"/>.</param>
        public void AlarmElapsed(int index) 
        {
            string inAlarmMsg = $"Alarm {index + 1} went OFF | {_model.Alarms[index].Sound}";
            _model.Alarms[index].AlarmStatusMessage = inAlarmMsg;
            _model.Alarms[index].InAlarm = true;
            _setAlarmSelection(index,inAlarmMsg);
            _toggleSnoozeAlarm(true);
            _toggleStopAlarm(true);
        }
        #endregion


        #region Register Methods
        /// <summary>
        /// Registers a View's <see cref="ToggleAddAlarm"/> method.
        /// </summary>
        /// <param name="addAlarm">The <see cref="ToggleAddAlarm"/> to use.</param>
        public void RegisterToggleAddAlarm(ToggleAddAlarm addAlarm) => _toggleAddAlarm = addAlarm;

        /// <summary>
        /// Registers a View's <see cref="ToggleEditAlarm"/> method.
        /// </summary>
        /// <param name="editAlarm">The <see cref="ToggleEditAlarm"/> to use.</param>
        public void RegisterToggleEditAlarm(ToggleEditAlarm editAlarm) => _toggleEditAlarm = editAlarm;

        /// <summary>
        /// Registers a View's <see cref="TogglSnoozeAlarm"/> method.
        /// </summary>
        /// <param name="snoozeAlarm">The <see cref="ToggleSnoozeAlarm"/> to use.</param>
        public void RegisterToggleSnoozeAlarm(ToggleSnoozeAlarm snoozeAlarm) => _toggleSnoozeAlarm = snoozeAlarm;

        /// <summary>
        /// Registers a View's <see cref="ToggleStopAlarm"/> method.
        /// </summary>
        /// <param name="stopAlarm">The <see cref="ToggleStopAlarm"/> to use.</param>
        public void RegisterToggleStopAlarm(ToggleStopAlarm stopAlarm) => _toggleStopAlarm = stopAlarm;

        /// <summary>
        /// Registers a View's <see cref="UpdateUIMessage"/> method.
        /// </summary>
        /// <param name="updateUI">The <see cref="UpdateUIMessage"/> to use.</param>
        public void RegisterUpdateUIMessage(UpdateUIMessage updateUI) => _updateUIMessage = updateUI;

        /// <summary>
        /// Registers a View's <see cref="UpdateTimers"/> method.
        /// </summary>
        /// <param name="updateTimers">The <see cref="UpdateTimers"/> method. </param>
        public void RegisterUpdateTimers(UpdateTimers updateTimers) => _updateTimers = updateTimers;

        /// <summary>
        /// Registers a View's <see cref="Snooze"/> method.
        /// </summary>
        /// <param name="snooze">The <see cref="Snooze"/> method.</param>
        public void RegisterSnooze(Snooze snooze) => _snooze = snooze;

        /// <summary>
        /// Registers a View's <see cref="SetAlarmSelection"/> method.
        /// </summary>
        /// <param name="setAlarmSelection">The <see cref="SetAlarmSelection"/> method.</param>
        public void RegisterSetAlarmSelection(SetAlarmSelection setAlarmSelection) => _setAlarmSelection = setAlarmSelection;
        #endregion
    }
}
