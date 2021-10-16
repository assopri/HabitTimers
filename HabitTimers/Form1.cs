using FormManagement;
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
        KeyboardHook _hookCtrlShiftOne = new KeyboardHook();
        KeyboardHook _hookCtrlShiftTwo = new KeyboardHook();
        KeyboardHook _hookCtrlShiftThree = new KeyboardHook();
        KeyboardHook _hookCtrlShiftFour = new KeyboardHook();
        KeyboardHook _hookCtrlShiftFive = new KeyboardHook();

        NotifyIcon _notifyIcon = new System.Windows.Forms.NotifyIcon();

        public Form1()
        {
            InitializeComponent();

            LoadFormSettings();

            InitKeyHooks();

            InitNotifyIcons();

            InitFormSize();

        }

        private void KillProcess(string v)
        {

            Process[] localByName = Process.GetProcessesByName(v);
            foreach (Process p in localByName)
            {
                p.Kill();
            }
        }

        private void InitFormSize()
        {

            this.Resize += delegate (object sender, EventArgs e)
            {
                if (WindowState == FormWindowState.Minimized) this.Hide();
            };

            if(!Debugger.IsAttached) this.WindowState = FormWindowState.Minimized;

        }
        private void InitNotifyIcons()
        {
            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.Icon = new System.Drawing.Icon("icon.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.MouseClick += delegate (object sender, MouseEventArgs args)
            {
                if (args.Button == MouseButtons.Left)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                }
            };

            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit", null, delegate (object sender, EventArgs args)
            {
                Close();
            });
        }

        private void InitKeyHooks()
        {
            _hookCtrlShiftOne.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(300);
            };
            _hookCtrlShiftOne.RegisterHotKey(ModifierKeysMy.Shift| ModifierKeysMy.Control,
                Keys.F1);

            _hookCtrlShiftTwo.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(600);
            };
            _hookCtrlShiftTwo.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F2);

            _hookCtrlShiftThree.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(900);
            };
            _hookCtrlShiftThree.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F3);

            _hookCtrlShiftFour.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(1200);
            };
            _hookCtrlShiftFour.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F4);

            _hookCtrlShiftFive.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(1500);
            };
            _hookCtrlShiftFive.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F5);
        }

        private void LaunchPomodoroTimer(int seconds)
        {
            if (_pomodoroTimerLaunchedFlag)
            {
                int secondsTillFinish = (int)(_pomodoroTimerFinishTime - DateTime.Now).TotalSeconds;
                _sythesizer.Speak("Timer is now launched. Will finish in " + secondsTillFinish/60 + "minutes, " + secondsTillFinish % 60 + " seconds");
                return;
            }
            if (DateTime.Now < _pomodoroTimerNextStartTime)
            {
                int secondsTillCanRestart = (int)(_pomodoroTimerNextStartTime - DateTime.Now).TotalSeconds;
                _sythesizer.Speak("You should still rest for "
                    + secondsTillCanRestart / 60 + "minutes, " + secondsTillCanRestart % 60 + " seconds");
             
                return;
            }
            int timeSec = seconds;
            int buffer = timeSec / 4;



            Delayed(timeSec, () =>
            {
                _sythesizer.Speak("Main time finished. Left " + buffer/60 + " minutes, " + (buffer % 60) + " seconds");
                Delayed(buffer, () =>
                {
                    _pomodoroTimerLaunchedFlag = false;
                    int restTime = timeSec / 2;
                    _sythesizer.Speak("Ready. Now - go activities, then change location, then mindfulness. ");
                    _pomodoroTimerNextStartTime = DateTime.Now.AddSeconds(restTime);

                    int secondsTillCanRestart = (int)(_pomodoroTimerNextStartTime - DateTime.Now).TotalSeconds;
                    _sythesizer.Speak("You should rest for "
                        + ((secondsTillCanRestart / 60 > 0) ? secondsTillCanRestart / 60 + "minutes ":"") + secondsTillCanRestart % 60 + " seconds");
                    
                    Delayed(restTime, () =>
                    {
                        _sythesizer.Speak("OK. Now you can start new working session. Please, achieve the flow state!");
                        StopVideoInBrowser();
                    });
                    Process.Start("https://www.youtube.com/watch?v=XQuR1OxYJt0");
                });
            }
            );
            _sythesizer.Speak("Timer for " + timeSec / 60 + " minutes, " + (timeSec % 60) + " seconds launched."); 
            // _pomodoroTimerStartTime = DateTime.Now;
            _pomodoroTimerFinishTime = DateTime.Now.AddSeconds(timeSec + buffer);
            _pomodoroTimerLaunchedFlag = true;
            //await Task.Delay(timeSec);

            //sythesizer.SpeakAsync(new Prompt("Main time finished. Left " + buffer + " seconds"));

            //await Task.Delay(buffer);

            //sythesizer.SpeakAsync(new Prompt("Ready")); 

        }

        private void StopVideoInBrowser()
        {
            try
            {
                Click("//*[@id="movie_player"]");
            }
            catch (Exception)
            {

            }
            if()//
        }

        public  void Click(string xpath)
        {
            EvaluateScript(string.Format("document.evaluate('{0}', document, null, XPathResult.ANY_TYPE, null).iterateNext().click();", xpath.Replace('\'', '\"')));

        }
        private void LoadFormSettings()
        {
            sePomodoroPeriod.Value = Properties.Settings.Default.PomodoroPeriod;
        }

        private void tbLaunchPeriodicTimer_Click(object sender, EventArgs e)
        {
            int prepareSeconds = 10;
            _sythesizer.Speak("You have " + prepareSeconds + " seconds to prepare for NSDR. Warm your hands. Lay down. After please make see mindfulness practice.");
                Delayed(prepareSeconds, () =>
                {
                    RemoveDistractors();

                    _sythesizer.Speak("NSDR Launched");
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=A6P_xLLlcGQ");
                    LaunchPeriodicTimer(120);
                }
            );
            
        }

        private void RemoveDistractors()
        {
            KillProcess("Telegram");
            KillProcess("Viber");
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
            LaunchPomodoroTimer(Convert.ToInt32(sePomodoroPeriod.Value));
        }


        Timer _currentPomodoroTimer = null;
        public void Delayed(int delaySec, Action action)
        {
            _currentPomodoroTimer = new Timer();
            _currentPomodoroTimer.Interval = delaySec * 1000;
            _currentPomodoroTimer.Tick += (s, e) => {
                _currentPomodoroTimer.Stop();
                action();
            };
            _currentPomodoroTimer.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PomodoroPeriod = (int)sePomodoroPeriod.Value;
            Properties.Settings.Default.Save();

            _hookCtrlShiftOne.Dispose();
            _hookCtrlShiftTwo.Dispose();
            _hookCtrlShiftThree.Dispose();
            _hookCtrlShiftFour.Dispose();
            _hookCtrlShiftFive.Dispose();

            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
        }

        private void btStopTimer_Click(object sender, EventArgs e)
        {
            if (_currentPomodoroTimer!=null && _currentPomodoroTimer.Enabled)
            {
                _currentPomodoroTimer.Stop();
                _sythesizer.Speak("Current timer stopped");
            }
            else
            {
                _sythesizer.Speak("Timer is not launched to be stopped. Hi hi hi");
            }
            
        }
    }
}
