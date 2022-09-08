using System.Timers;

namespace Alarm501_Library
{
    /// <summary>
    /// A Timer that has an Id used for tracking an <see cref="Alarm"/>
    /// </summary>
    public class AlarmTimer : Timer
    {
        #region Properties
        /// <summary>
        /// An Id for the <see cref="AlarmTimer"/>.
        /// </summary>
        public int Id;
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="AlarmTimer"/> class.
        /// </summary>
        /// <param name="interval">The interval of the timer in milli-seconds.</param>
        /// <param name="id">The <see cref="AlarmTimer"/>'s Id.</param>
        public AlarmTimer(double interval, int id) { Interval = interval; Id = id; }
        #endregion
    }
}
