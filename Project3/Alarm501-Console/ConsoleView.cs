using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alarm501_Library;

namespace Alarm501_Console
{
    class ConsoleView
    {
        #region Fields

        /// <summary>
        /// The <see cref="AlarmListM"/> model the <see cref="View"/> gets it's data from.
        /// </summary>
        private AlarmListM _model;

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
        /// index of selected Alarm
        /// </summary>
        private int selectedIndex = 0;

        /// <summary>
        /// Used to determine if 'add' will show as an option
        /// </summary>
        private bool canAdd = true;

        /// <summary>
        /// Used to determine if 'edit' will show as an option
        /// </summary>
        private bool canEdit;

        /// <summary>
        /// Used to determine if 'stop' will show as an option
        /// </summary>
        private bool canStop;

        /// <summary>
        /// Used to determine if 'snooze' will show as an option
        /// </summary>
        private bool canSnooze;

        private string message = "";

        bool keepLooping = true;
        #endregion

        #region constructor
        public ConsoleView(AlarmListM m)
        {
            _model = m;
        }
        #endregion

        #region methods
        private void refreshUI()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message + "\n\n");
            PrintAlarms();

            List<string> options = new List<string>();
            if (canAdd) options.Add("Add");
            if (_model.Alarms.Count > 1) options.Add("Pick a different alarm");
            if (canEdit) options.Add("Edit");
            if (canStop) options.Add("Stop");
            if (canSnooze) options.Add("snooZe");
            char command = PrintMenu(options);


            switch (command)
            {
                case 'A': //add alarm
                    AddSelected();
                    break;
                case 'P': //pick differnet alarm
                    Console.WriteLine("Which alarm?");
                    int i = GetIntInput(1, _model.Alarms.Count) - 1;
                    SetIndex(i, _model.Alarms[i].AlarmStatusMessage);
                    break;
                case 'E': //edit
                    EditSelected();
                    break;
                case 'S': //stop
                    StopSelected();
                    break;
                case 'Z': //snooze
                    SnoozeSelected();
                    break;
                case 'i': //invalid input
                    message = "Invalid Input!";
                    break;
                case 'X': //exit
                    _end();
                    keepLooping = false;
                    break;
            }
        }

        /// <summary>
        /// updates after every user input
        /// </summary>
        public void loop()
        {
            _start();
            while (keepLooping)
            {
                refreshUI();
            }
        }

        /// <summary>
        /// clears the console and prints the list of alarms from model
        /// </summary>
        private void PrintAlarms()
        {
            string list = "\t\tALARMS\n---------------------------------\n";

            if (_model.Alarms.Count == 0) list = list + "[No alarms set]\n";
            for (int i = 0; i < _model.Alarms.Count; i++)
            {
                list = list + (i + 1).ToString() + ". " + _model.Alarms[i].ToString();
                if (i == selectedIndex) list = list + " <------Selected";
                list = list + "\n";
            }
            list = list + "---------------------------------\n";
            Console.WriteLine(list);
        }

        /// <summary>
        /// for when the user selects the "Add" option
        /// </summary>
        private void AddSelected()
        {
            Alarm al = new Alarm(DateTime.Now, selectedIndex, AlarmSound.Beacon, true);
            AlarmEditor editor = new AlarmEditor(al, -1);

            al = editor.Loop();
            if (al != null) _addAlarm(al);
        }

        /// <summary>
        /// for when the user selects the "Edit" option
        /// </summary>
        private void EditSelected()
        {
            Alarm al = _model.Alarms[selectedIndex];
            AlarmEditor editor = new AlarmEditor(al, selectedIndex);

            al = editor.Loop();
            if (al != null) _editAlarm(selectedIndex, al);
        }

        /// <summary>
        /// for when the user selects the "Stop" option
        /// </summary>
        private void StopSelected()
        {
            _stopAlarm(selectedIndex);
        }

        /// <summary>
        /// for when the user selects the "snooZe" option
        /// </summary>
        private void SnoozeSelected()
        {
            _snoozeAlarm(selectedIndex);
        }

        /// <summary>
        /// Prompts user input and checks that it is valid
        /// </summary>
        /// <param name="options">List of avalable menu options a capitalized letter represents
        /// this choice as user input</param>
        /// <returns>the char the user typed if it was valid, or 'i' for invalid input</returns>
        public static char PrintMenu(List<string> options)
        {
            List<char> valadResults = new List<char>();
            Console.Write("\t\tMENU\n Type a ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Highlighted");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" letter\n");
            foreach (string s in options)
            {
                string prefix = "";
                char command = 'i';
                string suffix = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] >= 'A' && s[i] <= 'Z')
                    {
                        prefix = s.Substring(0, i);
                        command = s[i];
                        suffix = s.Substring(i + 1, s.Length - i - 1);
                        break;
                    }
                }
                Console.Write(prefix);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(command);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(suffix);
                valadResults.Add(command);
            }
            char result = 'i';
            try { result = Console.ReadLine().ToUpper()[0]; }
            catch { return 'i'; }


            if (valadResults.Contains(result)) return result;
            else return 'i'; //invalid input
        }

        /// <summary>
        /// Prompts user for an integer
        /// </summary>
        /// <param name="min">smallest accepted value</param>
        /// <param name="max">largest accepted value</param>
        /// <returns>User's input</returns>
        public static int GetIntInput(int min, int max)
        {
            if (min > max) throw new Exception("min must not exceed max");
            if (min == max) return min;
            bool keepTrying = true;
            while (keepTrying)
            {
                if (max - min == 1) Console.WriteLine("Enter number ({0} or {1}): ", min, max);
                else if (max - min == 2) Console.WriteLine("Enter number ({0}, {1}, {2}): ", min, min + 1, max);
                else Console.Write("Enter number ({0}, {1},...{2}): ", min, min + 1, max);
                Console.WriteLine(" and press 'Enter' key");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input >= min & input <= max)
                    {
                        return input;
                    }
                    Console.WriteLine("Out of bounds");
                }
                catch
                {
                    Console.WriteLine("Invalid. Input must be an integer.");
                }
            }
            return 0;
        }
        #endregion

        #region Delegate Methods
        /// <summary>
        /// Toggles the option to show the Add option in the menu
        /// </summary>
        /// <param name="b"></param>
        public void ToggleAddOption(bool b) => canAdd = b;

        /// <summary>
        /// Toggles the option to show the Edit option in the menu
        /// </summary>
        /// <param name="b"></param>
        public void ToggleEditOption(bool b) => canEdit = b;

        /// <summary>
        /// Toggles the option to show the Stop option in the menu
        /// </summary>
        /// <param name="b"></param>
        public void ToggleStopOption(bool b) => canStop = b;

        /// <summary>
        /// Toggles the option to show the Stop option in the menu
        /// </summary>
        /// <param name="b"></param>
        public void ToggleSnoozeOption(bool b) => canSnooze = b;

        public void PrintMessage(string msg)
        {
            message = msg;
        }

        /// <summary>
        /// Changes which alarm is currently selected
        /// </summary>
        /// <param name="i"></param>
        public void SetIndex(int i, string s)
        {
            selectedIndex = i;
            message = _model.Alarms[i].AlarmStatusMessage;
            refreshUI();
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
