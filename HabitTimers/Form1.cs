using HabitTimers.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabitTimers
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer _sythesizer = new SpeechSynthesizer();
        bool _pomodoroTimerLaunchedFlag = false;
        //DateTime _pomodoroTimerStartTime;
        DateTime _pomodoroTimerFinishTime;
        DateTime _pomodoroTimerNextStartTime;
        public Form1()
        {
            InitializeComponent();

            LoadFormSettings();
            // LaunchPeriodicTimer(120);
        }

        private void LoadFormSettings()
        {
            sePomodoroPeriod.Value = Properties.Settings.Default.PomodoroPeriod;
        }

        private void tbLaunchPeriodicTimer_Click(object sender, EventArgs e)
        {
            int prepareSeconds = 5;
            _sythesizer.Speak("You have " + prepareSeconds + " seconds to prepare for NSDR. Warm your hands. Lay down. After please make see listen feel practice.");
                Delayed(prepareSeconds, () =>
                {
                    _sythesizer.Speak("NSDR Launched");
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=A6P_xLLlcGQ");
                    LaunchPeriodicTimer(120);
                }
            );
            
        }

        private void LaunchPeriodicTimer(int intervalSec)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

            t.Interval = intervalSec*1000; // specify interval time as you want
            t.Tick += new EventHandler(periodicTimer_Tick);
            t.Start();
        }

        private void periodicTimer_Tick(object sender, EventArgs e)
        {
            string audioFileNameToLaunch = Utilities.GetRandomFileFromFolder(
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "audios"));
            if(String.IsNullOrEmpty(audioFileNameToLaunch))
                Console.Beep();
            else
            {
                System.Diagnostics.Process.Start(audioFileNameToLaunch);
            }
            //TODO: close started aspp
        }

        private void btPomodoro_Click(object sender, EventArgs e)
        {
            if(_pomodoroTimerLaunchedFlag)
            {
                _sythesizer.Speak("Timer is now launched. Will finish in " + (_pomodoroTimerFinishTime - DateTime.Now).Seconds + " seconds");
                return;
            }
            if(DateTime.Now < _pomodoroTimerNextStartTime)
            {
                _sythesizer.Speak("You should rest " 
                    + (_pomodoroTimerNextStartTime - DateTime.Now).Seconds + " more seconds");
                return;
            }
            int timeSec = Convert.ToInt32(sePomodoroPeriod.Value);
            int buffer = timeSec / 4;



            Delayed(timeSec, () =>
                { 
                    _sythesizer.Speak("Main time finished. Left " + buffer + " seconds.");
                    Delayed(buffer, () =>
                    {
                        _sythesizer.Speak("Ready");
                        _pomodoroTimerLaunchedFlag = false;
                        _pomodoroTimerNextStartTime = DateTime.Now.AddSeconds(timeSec / 2);
                        Process.Start("https://www.youtube.com/watch?v=XQuR1OxYJt0");
                    });
                }
            );
            _sythesizer.Speak("Timer for " + timeSec/60 + " minutes launched.");
            // _pomodoroTimerStartTime = DateTime.Now;
            _pomodoroTimerFinishTime = DateTime.Now.AddSeconds(timeSec+ buffer);
            _pomodoroTimerLaunchedFlag = true;
            //await Task.Delay(timeSec);

            //sythesizer.SpeakAsync(new Prompt("Main time finished. Left " + buffer + " seconds"));

            //await Task.Delay(buffer);

            //sythesizer.SpeakAsync(new Prompt("Ready")); 

        }

        public void Delayed(int delaySec, Action action)
        {
            Timer timer = new Timer();
            timer.Interval = delaySec * 1000;
            timer.Tick += (s, e) => {
                action();
                timer.Stop();
            };
            timer.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PomodoroPeriod = (int)sePomodoroPeriod.Value;
            Properties.Settings.Default.Save();
        }
    }
}
