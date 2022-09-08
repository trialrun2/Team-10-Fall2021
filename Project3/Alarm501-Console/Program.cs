using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alarm501_Library;

namespace Alarm501_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmListM model = new AlarmListM();

            FileHandler fileHandler = new FileHandler(model);
            TimerObserver observer = new TimerObserver(model);
            Controller controller = new Controller(model, fileHandler.SaveFile, fileHandler.LoadFile);

            ConsoleView view = new ConsoleView(model);

            controller.RegisterSetAlarmSelection(view.SetIndex);
            controller.RegisterToggleAddAlarm(view.ToggleAddOption);
            controller.RegisterToggleEditAlarm(view.ToggleEditOption);
            controller.RegisterToggleSnoozeAlarm(view.ToggleSnoozeOption);
            controller.RegisterToggleStopAlarm(view.ToggleStopOption);
            controller.RegisterUpdateUIMessage(view.PrintMessage);
            controller.RegisterSnooze(observer.Snooze);
            controller.RegisterUpdateTimers(observer.UpdateTimers);
            

            view.RegisterStart(controller.Start);
            view.RegisterEnd(controller.End);
            view.RegisterAddAlarm(controller.AddAlarm);
            view.RegisterEditAlarm(controller.EditAlarm);
            view.RegisterSelectionChanged(controller.SelectionChanged);
            view.RegisterSnoozeAlarm(controller.SnoozeAlarm);
            view.RegisterStopAlarm(controller.StopAlarm);

            observer.RegisterElapsedHandlers(controller.AlarmElapsed, controller.SnoozeAlarmElapsed);

            view.loop();
        }
    }
}
