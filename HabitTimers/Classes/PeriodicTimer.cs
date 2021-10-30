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
        Action _periodicAction = null;
        Action _stopAction = null;
        public PeriodicTimer(int period, int periodicProcessLength, Action periodicAction, Action stopAction)
        {
            _period = 5;//period;
            _periodicProcessLength = 15;//periodicProcessLength;
            _periodicAction = periodicAction;
            _stopAction = stopAction;
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
            if ((DateTime.Now - _periodicTimerStartedDateTime).TotalSeconds >= _periodicProcessLength)
            {
                _periodicTimer.Stop();
                _stopAction.Invoke();
            }
            else
            {
                _periodicAction.Invoke();
            }
        }

    }
}
