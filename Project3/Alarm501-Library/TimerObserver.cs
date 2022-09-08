using System;
using System.Collections.Generic;
using System.Timers;

namespace Alarm501_Library
{
    /// <summary>
    /// A class that keeps track of the <see cref="Timer"/>s.
    /// </summary>
    public class TimerObserver
    {
        #region Fields
        /// <summary>
        /// The <see cref="AlarmListM"/> that tracks the <see cref="Alarm"/>s.
        /// </summary>
        private AlarmListM _model;

        /// <summary>
        /// The Array of <see cref="AlarmTimer"/>s to track.
        /// </summary>
        private AlarmTimer[] _timers = new AlarmTimer[5];

        /// <summary>
        /// The Array of <see cref="AlarmTimer"/>s that track snoozing.
        /// </summary>
        private AlarmTimer[] _snoozeTimers = new AlarmTimer[5];

        ///// <summary>
        ///// The <see cref="Timer"/> to keep track of snoozing.
        ///// </summary>
        //private Timer _snoozeTimer;

        /// <summary>
        /// A <see cref="Delegate"/> method for when an <see cref="AlarmTimer"/> has elapsed.
        /// </summary>
        private TimerElapsed _elapsed;

        /// <summary>
        /// A <see cref="Delegate"/> method for when the snooze <see cref="Timer"/> has elapsed.
        /// </summary>
        private TimerElapsed _snoozeElapsed;

        //private AlarmTimer _lastElapsed = null;
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="TimerObserver"/> class.
        /// </summary>
        /// <param name="model">The <see cref="AlarmListM"/> the <see cref="TimerObserver"/> should be based on.</param>
        public TimerObserver(AlarmListM model)
        {
            _model = model;
            //_snoozeTimer = new Timer();
            //_snoozeTimer.Elapsed += Snooze_Elapsed;
        }
        #endregion


        #region EventHandlers
        /// <summary>
        /// An EventHandler that triggers when an <see cref="AlarmTimer"/> has elapsed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            AlarmTimer timer = sender as AlarmTimer;
            timer.Stop();
            //_lastElapsed = timer;
            _elapsed(timer.Id);
        }

        /// <summary>
        /// An EventHandler that triggers when the snooze <see cref="Timer"/> has elapsed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Snooze_Elapsed(object sender, ElapsedEventArgs e) 
        {
            AlarmTimer timer = sender as AlarmTimer;
            timer.Stop(); 
            _snoozeElapsed(timer.Id); 
        }
        #endregion


        #region Methods
        /// <summary>
        /// Registers the <see cref="TimerElapsed"/>s for the <see cref="Alarm"/>s.
        /// </summary>
        /// <param name="elapsed"></param>
        /// <param name="snooze"></param>
        public void RegisterElapsedHandlers(TimerElapsed elapsed, TimerElapsed snooze)
        {
            _elapsed = elapsed;
            _snoozeElapsed = snooze;
        }

        /// <summary>
        /// Updates the Array of <see cref="AlarmTimer"/>s with the <see cref="Alarm"/>s in the <see cref="AlarmListM"/>.
        /// </summary>
        public void UpdateTimers()
        {
            lock (this)
            {
                foreach (AlarmTimer timer in _timers) if (timer != null) { RemoveTimer(timer.Id); }

                for (int i = 0; i < _model.Alarms.Count; i++)
                {
                    Alarm alarm = _model.Alarms[i];
                    AddTimer(i, CalculateTime(alarm.Time), alarm.Enabled);
                    AddSnoozeTimer(i, alarm.SnoozeTime);
                }
            }
        }

        /// <summary>
        /// Creates a snooze <see cref="Timer"/>.
        /// </summary>
        /// <param name="index">The index of the corrisponding <see cref="Alarm"/>.</param>
        public void Snooze(int index)
        {
            lock (this)
            {
                //_snoozeTimer.Interval = _model.Alarms[_lastElapsed.Id].SnoozeTime * 60000 + 1; // add 1 to prevent error if snoozetime is 0
                //_snoozeTimer.Interval = _model.Alarms[_lastElapsed.Id].SnoozeTime * 1000 + 1;
                //_snoozeTimer.Start();

                _snoozeTimers[index].Start();
            }
        }

        /// <summary>
        /// Adds an <see cref="AlarmTimer"/> to the <see cref="List{T}"/> of AlarmTimers
        /// </summary>
        /// <param name="index">The index of the corrisponding <see cref="Alarm"/>.</param>
        /// <param name="interval">The interval of the <see cref="AlarmTimer"/> in milliseconds.</param>
        /// <param name="enabled">Whether or not the <see cref="AlarmTimer"/> is enabled.</param>
        private void AddTimer(int index, double interval, bool enabled)
        {
            AlarmTimer timer = new AlarmTimer(interval, index) { Enabled = enabled };
            timer.Elapsed += Timer_Elapsed;
            //timer.Start(); Should be unecessary due to enabled assignment. But ill keep it here incase not.
            _timers[index] = timer;
        }

        /// <summary>
        /// Adds an <see cref="AlarmTimer"/> into the snooze Timer array.
        /// </summary>
        /// <param name="index">The index of the <see cref="AlarmTimer"/>.</param>
        /// <param name="interval">the interval of the <see cref="AlarmTimer"/>.</param>
        private void AddSnoozeTimer(int index, double interval)
        {
            AlarmTimer timer = new AlarmTimer(interval * 60000 + 1, index) { Enabled = false }; 
            timer.Elapsed += Snooze_Elapsed;
            _snoozeTimers[index] = timer;
        }

        /// <summary>
        /// Removes the <see cref="AlarmTimer"/> at the given index.
        /// </summary>
        /// <param name="index">The index of the <see cref="AlarmTimer"/> to remove.</param>
        private void RemoveTimer(int index) { DisableTimer(index); _timers[index] = null; _snoozeTimers[index] = null; }

        /// <summary>
        /// Disables the <see cref="AlarmTimer"/> at the given index.
        /// </summary>
        /// <param name="index">The index of the <see cref="AlarmTimer"/> to disable.</param>
        private void DisableTimer(int index) { _timers[index].Enabled = false; _snoozeTimers[index].Enabled = false; }

        /// <summary>
        /// Calculates the time until the next instance of the <see cref="Alarm"/>'s time.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> the <see cref="Alarm"/> is supposed to go off at.</param>
        /// <returns></returns>
        private int CalculateTime(DateTime dateTime)
        {
            if (dateTime > DateTime.Now) return (int)(dateTime - DateTime.Now).TotalMilliseconds;
            else return (int)(dateTime.AddDays(1) - DateTime.Now).TotalMilliseconds;
        }
        #endregion
    }
}
