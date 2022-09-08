using System;

namespace Alarm501_Library
{
    /// <summary>
    /// A representation of an Alarm
    /// </summary>
    [Serializable]
    public class Alarm
    {
        #region Fields
        /// <summary>
        /// The time the <see cref="Alarm"/> is suppposed to go off.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// How long to snooze the <see cref="Alarm"/> for in minutes.
        /// </summary>
        public int SnoozeTime { get; set; }

        /// <summary>
        /// What <see cref="AlarmSound"/> plays when the <see cref="Alarm"/> goes off.
        /// </summary>
        public AlarmSound Sound { get; set; }

        /// <summary>
        /// Whether or not the <see cref="Alarm"/> is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Message for UI to let user know the state of the <see cref="Alarm"/>.
        /// </summary>
        public string AlarmStatusMessage { get; set; }

        /// <summary>
        /// True if <see cref="AlarmTimer"/> has elapsed and user has not acknowledged.>
        /// </summary>
        public bool InAlarm { get; set; }
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="Alarm"/> class.
        /// </summary>
        /// <param name="time">The time the <see cref="Alarm"/> is supposed to go off as a <see cref="DateTime"/>.</param>
        /// <param name="st">The time in seconds to snooze the <see cref="Alarm"/> for as an <see cref="int"/>.</param>
        /// <param name="sound">What <see cref="AlarmSound"/> to play when the <see cref="Alarm"/> goes off.</param>
        /// <param name="enabled">Whether or not the <see cref="Alarm"/> is enabled as a <see cref="bool"/>.</param>
        public Alarm(DateTime time, int st, AlarmSound sound, bool enabled)
        {
            Time = DateTime.Today + time.TimeOfDay;
            SnoozeTime = st;
            Sound = sound;
            Enabled = enabled;
            AlarmStatusMessage = Enabled ? "Running." : "Off.";
            InAlarm = false;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="Alarm"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="Alarm"/>.</returns>
        public override string ToString()
        {

            string isEnabled = Enabled ? "on" : "off";
            string minutes = (Time.TimeOfDay.Minutes < 10) ? $"0{Time.TimeOfDay.Minutes}" : $"{Time.TimeOfDay.Minutes}";
            string hours;
            string timeLetters;
            string alarmTime;

            if (Time.TimeOfDay.Hours >= 12)
            {
                timeLetters = "pm";
                if (Time.TimeOfDay.Hours != 12)
                {
                    hours = (Time.TimeOfDay.Hours - 12 < 10) ? $"0{Time.TimeOfDay.Hours - 12}" : $"{Time.TimeOfDay.Hours - 12}";
                    alarmTime = $"{hours}:{minutes}";
                }
                else alarmTime = $"{Time.TimeOfDay.Hours}:{minutes}";
            }
            else
            {
                timeLetters = "am";
                if (Time.TimeOfDay.Hours != 0)
                {
                    hours = (Time.TimeOfDay.Hours < 10) ? $"0{Time.TimeOfDay.Hours}" : $"{Time.TimeOfDay.Hours}";
                    alarmTime = $"{hours}:{minutes}";
                }
                else alarmTime = $"{Time.TimeOfDay.Hours}:{minutes}";
            }

            return $"{alarmTime} {timeLetters} {isEnabled} | {Sound}";
        }
        #endregion
    }
}
