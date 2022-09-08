using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Alarm501_Library;

namespace Alarm501_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AlarmListM model = new AlarmListM();
            
            FileHandler fileHandler = new FileHandler(model);
            TimerObserver observer = new TimerObserver(model);
            Controller controller = new Controller(model, fileHandler.SaveFile, fileHandler.LoadFile);

            AlarmDialog dialog = new AlarmDialog();
            View view = new View(model, dialog);

            controller.RegisterToggleAddAlarm(view.toggleAddButton);
            controller.RegisterToggleEditAlarm(view.toggleEditButton);
            controller.RegisterToggleSnoozeAlarm(view.toggleSnoozeButton);
            controller.RegisterToggleStopAlarm(view.toggleStopButton);
            controller.RegisterUpdateUIMessage(view.updateUIMessage);
            controller.RegisterSnooze(observer.Snooze);
            controller.RegisterUpdateTimers(observer.UpdateTimers);
            controller.RegisterSetAlarmSelection(view.setAlarmSelection);

            view.RegisterStart(controller.Start);
            view.RegisterEnd(controller.End);
            view.RegisterAddAlarm(controller.AddAlarm);
            view.RegisterEditAlarm(controller.EditAlarm);
            view.RegisterSelectionChanged(controller.SelectionChanged);
            view.RegisterSnoozeAlarm(controller.SnoozeAlarm);
            view.RegisterStopAlarm(controller.StopAlarm);

            observer.RegisterElapsedHandlers(controller.AlarmElapsed, controller.SnoozeAlarmElapsed);

            Application.Run(view);
        }
    }
}
