using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501_Library
{
    /// <summary>
    /// A model class that contains a <see cref="BindingList{T}"/> of <see cref="Alarm"/>s.
    /// </summary>
    public class AlarmListM
    {
        #region Properties
        /// <summary>
        /// A <see cref="BindingList{T}"/> of <see cref="Alarm"/>s to keep track of the programms alarms.
        /// </summary>
        public BindingList<Alarm> Alarms { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates a new instance of the <see cref="Alarm"/> class.
        /// </summary>
        public AlarmListM() => Alarms = new BindingList<Alarm>();
        #endregion


        #region Methods
        /// <summary>
        /// Adds a new <see cref="Alarm"/> to the model.
        /// </summary>
        /// <param name="alarm">The <see cref="Alarm"/> to add.</param>
        public void AddAlarm(Alarm alarm) => Alarms.Add(alarm);

        /// <summary>
        /// Edits a currently existing <see cref="Alarm"/> in the model.
        /// </summary>
        /// <param name="index">The <see cref="Alarm"/>'s index.</param>
        /// <param name="alarm">The new <see cref="Alarm"/> to insert.</param>
        public void EditAlarm(int index, Alarm alarm)
        {
            Alarms.RemoveAt(index);
            Alarms.Insert(index, alarm);
        }
        #endregion
    }
}
