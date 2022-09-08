using System;

namespace Alarm501_Library
{
    #region FileHandler Methods
    /// <summary>
    /// A <see cref="Delegate"/> that saves a file.
    /// </summary>
    public delegate void SaveFile();

    /// <summary>
    /// A <see cref="Delegate"/> that loads a file.
    /// </summary>
    public delegate void LoadFile();
    #endregion


    #region View Methods
    /// <summary>
    /// A <see cref="Delegate"/> that updates the UI message to the user
    /// when events happen, such as when an alarm goes off or when the
    /// user changes the alarm selection.
    /// </summary>
    /// <param name="newMsg"></param>
    public delegate void UpdateUIMessage(string newMsg);

    /// <summary>
    /// A <see cref="Delegate"/> that sets which alarm object the UI
    /// currently has selected. When an alarm that goes off, the alarm
    /// currently selected in the UI gets changed to that alarm.
    /// </summary>
    /// <param name="newIndex"></param>
    public delegate void SetAlarmSelection(int newIndex, string newUIMsg);

    /// <summary>
    /// A <see cref="Delegate"/> that toggles the availability of the
    /// Add Alarm functionality. Starts enabled, then when the number
    /// of alarms in the list reaches some max, it gets disabled.
    /// </summary>
    /// <param name="OnOff"></param>
    public delegate void ToggleAddAlarm(bool OnOff);

    /// <summary>
    /// A <see cref="Delegate"/> that toggles the availability of the
    /// Edit Alarm functionality. The user can only edit an alarm when one
    /// is selected in the UI.
    /// </summary>
    /// <param name="OnOff"></param>
    public delegate void ToggleEditAlarm(bool OnOff);

    /// <summary>
    /// A <see cref="Delegate"/> that toggles the availability of the
    /// Snooze Alarm functionality. Only enabled when the currently selected alarm
    /// is going off.
    /// </summary>
    /// <param name="OnOff"></param>
    public delegate void ToggleSnoozeAlarm(bool OnOff);

    /// <summary>
    /// A <see cref="Delegate"/> that toggles the availability of the
    /// Stop Alarm functionality. Only enabled when the currently selected alarm
    /// is going off.
    /// </summary>
    /// <param name="OnOff"></param>
    public delegate void ToggleStopAlarm(bool OnOff);
    #endregion


    #region Controller Methods
    /// <summary>
    /// A <see cref="Delegate"/> that handles when a timer has elased.
    /// </summary>
    /// <param name="index"></param>
    public delegate void TimerElapsed(int index);

    /// <summary>
    /// A <see cref="Delegate"/> for when a user wants to add an <see cref="Alarm"/>.
    /// </summary>
    /// <param name="alarm"> Alarm object to be added to the model. </param>
    public delegate void AddAlarm(Alarm alarm);

    /// <summary>
    /// A <see cref="Delegate"/> for when a user wants to Edit an <see cref="Alarm"/>.
    /// </summary>
    public delegate void EditAlarm(int index, Alarm alarm);

    /// <summary>
    /// A <see cref="Delegate"/> for when a user wants to Snooze an <see cref="Alarm"/>.
    /// </summary>
    public delegate void SnoozeAlarm(int index);

    /// <summary>
    /// A <see cref="Delegate"/> for when a user wants to stop an <see cref="Alarm"/>.
    /// </summary>
    public delegate void StopAlarm(int index);

    /// <summary>
    /// A <see cref="Delegate"/> that handles when the <see cref="Alarm"/> selected changes.
    /// </summary>
    public delegate void SelectionChanged(int index);

    /// <summary>
    /// A <see cref="Delegate"/> that adds an <see cref="Alarm"/>.
    /// </summary>
    /// <param name="alarm">The <see cref="Alarm"/> to add.</param>
    public delegate void SetAlarm(Alarm alarm);

    /// <summary>
    /// A <see cref="Delegate"/> that edits an existing <see cref="Alarm"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="Alarm"/>.</param>
    /// <param name="alarm">The <see cref="Alarm"/> to add.</param>
    public delegate void SetEditAlarm(int index, Alarm alarm);

    /// <summary>
    /// A <see cref="Delegate"/> for when the program starts.
    /// </summary>
    public delegate void Start();

    /// <summary>
    /// A <see cref="Delegate"/> for when the program ends.
    /// </summary>
    public delegate void End();
    #endregion


    #region TimerObserverMethods
    /// <summary>
    /// A <see cref="Delegate"/> for when snoozing an <see cref="AlarmTimer"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="AlarmTimer"/></param>
    public delegate void Snooze(int index);

    /// <summary>
    /// A <see cref="Delegate"/> that updates all the <see cref="AlarmTimer"/>s.
    /// </summary>
    public delegate void UpdateTimers();
    #endregion
}
