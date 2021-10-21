using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace HabitTimers.Classes
{
    class PeriodicTimer
    {
        DateTime _periodicTimerStartedDateTime = DateTime.Now;
        int _periodicProcessLength = 0;
        int _period = 0;
        Timer _periodicTimer = null;
        public PeriodicTimer(int period, int periodicProcessLength)
        {
            _period = period;
            _periodicProcessLength = periodicProcessLength;
        }
        public void Launch()
        {
            _periodicTimer = new System.Windows.Forms.Timer();

            _periodicTimer.Interval = _period * 1000; // specify interval time as you want
            _periodicTimer.Tick += new EventHandler(periodicTimer_Tick);
            
            _periodicTimer.Start();
        }

        private void periodicTimer_Tick(object sender, EventArgs e)
        {
            if ((_periodicTimerStartedDateTime - DateTime.Now).TotalSeconds >= _periodicProcessLength)
            {
                _periodicTimer.Stop();
            }
            else
            {

                string audioFileNameToLaunch = Utilities.GetRandomFileFromFolder(
                    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "audios"));
                if (String.IsNullOrEmpty(audioFileNameToLaunch))
                    Console.Beep();
                else
                {
                    System.Diagnostics.Process.Start(audioFileNameToLaunch);
                }
            }
        }

    }
}
