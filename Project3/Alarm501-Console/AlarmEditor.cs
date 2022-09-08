using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alarm501_Library;

namespace Alarm501_Console
{
    class AlarmEditor
    {
        #region fields
        private int index;

        private DateTime time;

        private int snoozeTime;

        private AlarmSound sound;

        private bool enabled;

        #endregion

        #region constructor
        /// <summary>
        /// Constructs a new instance of AlarmEditor
        /// </summary>
        /// <param name="al">alarm object to be edited</param>
        public AlarmEditor(Alarm al, int i)
        {
            index = i;
            time = al.Time;
            snoozeTime = al.SnoozeTime;
            sound = al.Sound;
            enabled = al.Enabled;
        }
        #endregion

        #region methods
        /// <summary>
        /// displays menu until user selects done or cancel
        /// </summary>
        /// <returns></returns>
        public Alarm Loop()
        {
            while (true)
            {
                Console.Clear();
                printAlarm();

                List<String> options = new List<string>();
                options.Add("Time");
                options.Add("Sound");
                if (enabled) options.Add("turn Off");
                else options.Add("turn On");
                options.Add("snooZe durration");
                options.Add("Cancel");
                options.Add("Done");


                char command = ConsoleView.PrintMenu(options);

                switch (command)
                {
                    case 'T': //time
                        changeTime();
                        break;
                    case 'S': //sound
                        changeSound();
                        break;
                    case 'O': //on/off
                        toggleOnOff();
                        break;
                    case 'Z': //snoozeTime
                        chageSnoozeTime();
                        break;
                    case 'C': //cancel
                        return null;
                    case 'D': //done
                        return new Alarm(time, snoozeTime, sound, enabled);
                }

            }
        
        }

        /// <summary>
        /// gets user input for the time and updates it
        /// </summary>
        private void changeTime()
        {
            Console.WriteLine("\n\nType the HOUR");
            int hour = ConsoleView.GetIntInput(0, 23);

            Console.WriteLine("Type the Minute");
            int minute = ConsoleView.GetIntInput(0, 59);

            Console.WriteLine("Type the Seconds");
            int seconds = ConsoleView.GetIntInput(0, 59);

            time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, seconds);
            if (time < DateTime.Now) time.AddDays(1);
        }

        /// <summary>
        /// gets user input for the alarm sound
        /// </summary>
        private void changeSound()
        {
            Console.WriteLine("Select an alarm sound");
            String[] sounds = Enum.GetNames(typeof(AlarmSound));
            for (int i = 0; i < sounds.Length; i++)
            {
                Console.WriteLine(i + ". " + sounds[i]);
            }
            sound = (AlarmSound)ConsoleView.GetIntInput(0, sounds.Length - 1);
        }

        /// <summary>
        /// toggles the active property
        /// </summary>
        private void toggleOnOff()
        {
            if (enabled) enabled = false;
            else enabled = true;
        }

        /// <summary>
        /// gets user input for snooze time
        /// </summary>
        private void chageSnoozeTime()
        {
            Console.WriteLine("\n\nType duration of snooze in Minutes");
            snoozeTime = ConsoleView.GetIntInput(0, 30);
        }

        /// <summary>
        /// prints all alarm details, including snooze time 
        /// </summary>
        private void printAlarm()
        {
            if (index < 0) Console.WriteLine("\t\tNew Alarm");
            else Console.WriteLine("\t\tEdit Alarm {0}", index + 1);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Time: " + time.ToString("t"));
            Console.WriteLine("Sound: " + sound.ToString());
            Console.WriteLine("Enabled: " + enabled.ToString());
            Console.WriteLine("Snooze: " + snoozeTime + " minutes");
            Console.WriteLine("---------------------------------\n\n");

        }
        #endregion
    }
}
