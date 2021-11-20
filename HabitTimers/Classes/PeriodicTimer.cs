using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        //bool _launchActionImmediately = false;
        public PeriodicTimer(int period, int periodicProcessLength, Action periodicAction, Action stopAction)//,
           // bool launchActionImmediately)
        {
            _period = period;
            _periodicProcessLength = periodicProcessLength;
            if(Debugger.IsAttached)
            {
                _period = 5;
                _periodicProcessLength = 15;
            }
            _periodicAction = periodicAction;
            _stopAction = stopAction;
            //_launchActionImmediately = launchActionImmediately;

        }
        public void Launch()
        {
            //if(_launchActionImmediately) _periodicAction?.Invoke();

            _periodicTimer = new System.Windows.Forms.Timer();

            _periodicTimer.Interval = _period * 1000; // specify interval time as you want
            _periodicTimer.Tick += new EventHandler(periodicTimer_Tick);
            
            _periodicTimer.Start();
        }

        private void periodicTimer_Tick(object sender, EventArgs e)
        {
            if (_periodicProcessLength > 0 && 
                (DateTime.Now - _periodicTimerStartedDateTime).TotalSeconds >= _periodicProcessLength)
            {
                _periodicTimer.Stop();
                _stopAction?.Invoke();
            }
            else
            {
                _periodicAction?.Invoke();
            }
        }

    }
}
