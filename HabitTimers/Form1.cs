using CefSharp;
using FormManagement;
using HabitTimers.Classes;
using HabitTimers.Classes.StateIndication;
using HabitTimers.Forms;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabitTimers
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer _sythesizer = new SpeechSynthesizer();

        //DateTime _pomodoroTimerStartTime;
        DateTime _pomodoroTimerFinishTime;
        DateTime _pomodoroTimerNextStartTime;
        KeyboardHook _hookCtrlShiftFOne = new KeyboardHook();
        KeyboardHook _hookCtrlShiftFTwo = new KeyboardHook();
        KeyboardHook _hookCtrlShiftFThree = new KeyboardHook();
        KeyboardHook _hookCtrlShiftFFour = new KeyboardHook();
        KeyboardHook _hookCtrlShiftFFive = new KeyboardHook();
        KeyboardHook _hookCtrlShiftFTwelve = new KeyboardHook();

        KeyboardHook _hookCtrlShiftPlus = new KeyboardHook();

        NotifyIcon _notifyIcon = new System.Windows.Forms.NotifyIcon();

        PomodoroTimerStates _pomodoroTimerStates = PomodoroTimerStates.Stopped;

        private ImageContainerForm _reminderForm = null;

        public Form1()
        {
            InitializeComponent();

            LoadFormSettings();

            InitKeyHooks();

            InitNotifyIcons();

            InitFormSize();

            PeriodicTimer neutralityReminder = new PeriodicTimer(
                5000,
                0,
                () =>
                {
                    if (_reminderForm == null || _reminderForm.IsDisposed) {

                        _reminderForm = new ImageContainerForm("Нейтральность",
                            @"
(Лучше возле зеркала)
1. Физио зевок + 'я во да' (3) - выдох со звуком
2. Расслабляюсь
3. Расфокусирую взгляд");
                        
                        _reminderForm.Show();
                    }
                },
                null
                );

            neutralityReminder.Launch();

            PeriodicTimer kegelReminder = new PeriodicTimer(
                10000,
                0,
                () =>
                {
                    if (_reminderForm == null || _reminderForm.IsDisposed)
                    {

                        _reminderForm = new ImageContainerForm("Кегель",
                            @"
1. Кегель 'здоровье' (3)
(образ закачки)
2. Произвольно по 5 махов ногой");

                        _reminderForm.Show();
                    }
                },
                null
                );

            kegelReminder.Launch();

            PeriodicTimer actingReminder = new PeriodicTimer(
                4500,
                0,
                () =>
                {
                    LaunchActingReminder();
                }
                ,
                null
                );

            actingReminder.Launch();

        }

        private void LaunchActingReminder()
        {
            List<string> videos = new List<string> {
                        "https://www.youtube.com/watch?v=Wq3N8rQT7Iw&t=7s",
                        "https://youtu.be/v2it8FmNdjk?t=105",
                        "https://youtu.be/3xGImir8Qhs?t=29",
                        "https://youtu.be/95RXL6kFuX0?t=183",
                        "https://youtu.be/7T2sX-99ChE?t=117",
                        "https://youtu.be/DblcE1oE8Jg?t=228",
            "https://youtu.be/XBaMy9ExDLc?t=1010",
            "https://youtu.be/DblcE1oE8Jg?t=81",
            "https://youtu.be/4D53tXI20uU?t=30",
            "https://youtu.be/4D53tXI20uU?t=82",
            "https://youtu.be/EDLf38odP2E?t=99",
            "https://youtu.be/EDLf38odP2E?t=118"};

            Process.Start(videos[new Random().Next(videos.Count)]);

            //if (_reminderForm == null || _reminderForm.IsDisposed)
            //{

            //                    _reminderForm = new ImageContainerForm("Лицедейство",
            //                        @"
            //(Лучше возле зеркала)
            //1. Внутренний монолог
            //2. Мимика
            //3. Пластика", 10, () => { 
            //                            LaunchVideoByLink(videos[new Random().Next(videos.Count)]);
            //                            new Thread(() =>
            //                            {
            //                                Thread.CurrentThread.IsBackground = true;
            //                                Thread.Sleep(10 * 1000);
            //                                StopBrowserProcess();
            //                            }).Start();
            //                        });

            //_reminderForm.Show();
            //}
        }

        //private string CefSharpCacheLocalPath = @"Cefsharp\Cache";
        //public void CefGlobalInit()
        //{
        //    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), CefSharpCacheLocalPath);
        //    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        //    CefSharp.Cef.Initialize(new CefSharp.WinForms.CefSettings() { RootCachePath = path });

        //}
        //public void CefShutdown()
        //{
        //    try
        //    {
        //        Cef.Shutdown();
        //    }
        //    catch (Exception exp)
        //    {

        //    }
        //}

        //private void InitBrowser()
        //{
        //    CefGlobalInit();

        //    RequestContextSettings requestContextSettings = new RequestContextSettings();
        //    requestContextSettings.PersistSessionCookies = true;
        //    requestContextSettings.PersistUserPreferences = true;

        //    string cachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        //        CefSharpCacheLocalPath,
        //        "habby");

        //    if (!Directory.Exists(cachePath)) Directory.CreateDirectory(cachePath);
        //    requestContextSettings.CachePath = cachePath;

        //    chromiumWebBrowser1.RequestContext = new RequestContext(requestContextSettings);
        //    chromiumWebBrowser1.IsBrowserInitializedChanged += ChromiumWebBrowser1_IsBrowserInitializedChanged;
        //    chromiumWebBrowser1.LoadUrlAsync("https://youtube.com");
        //}

        //private void ChromiumWebBrowser1_IsBrowserInitializedChanged(object sender, EventArgs e)
        //{
        //    using (var client = chromiumWebBrowser1.GetDevToolsClient())
        //    {
        //        _ = client.Network.SetUserAgentOverrideAsync("Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36");
        //    }
        //}

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

                if (WindowState == FormWindowState.Minimized)
                {
                    //ShowInTaskbar = false;
                    this.Hide();
                }
            };

            //if(!Debugger.IsAttached) 
            this.WindowState = FormWindowState.Minimized;

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
            //_notifyIcon.MouseClick += delegate (object sender, MouseEventArgs args)
            //{
            //    _notifyIcon.BalloonTipTitle = "title";
            //    _notifyIcon.BalloonTipText = "hello";
            //    _notifyIcon.ShowBalloonTip(1000);
            //};

            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit", null, delegate (object sender, EventArgs args)
            {
                Close();
            });
        }

        private void _notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitKeyHooks()
        {
            _hookCtrlShiftFOne.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(300);
            };
            _hookCtrlShiftFOne.RegisterHotKey(ModifierKeysMy.Shift| ModifierKeysMy.Control,
                Keys.F1);

            _hookCtrlShiftFTwo.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(600);
            };
            _hookCtrlShiftFTwo.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F2);

            _hookCtrlShiftFThree.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(900);
            };
            _hookCtrlShiftFThree.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F3);

            _hookCtrlShiftFFour.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(1200);
            };
            _hookCtrlShiftFFour.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F4);

            _hookCtrlShiftFFive.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchPomodoroTimer(1500);
            };
            _hookCtrlShiftFFive.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F5);

            _hookCtrlShiftFTwelve.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                LaunchActingReminder();
            };
            _hookCtrlShiftFTwelve.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.F12);

            _hookCtrlShiftPlus.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                if (CheckIfTimerLaunched()) return;
                if (CheckIfNewStartIsNotAvailable()) return;
                _sythesizer.Speak("You can start working session right now");
            };
            _hookCtrlShiftPlus.RegisterHotKey(ModifierKeysMy.Shift | ModifierKeysMy.Control,
                Keys.Oemplus);
        }
        int _buffer = 0;

        bool CheckIfTimerLaunched()
        {
            if (_pomodoroTimerStates == PomodoroTimerStates.Launched)
            {
                int secondsTillFinish = (int)(_pomodoroTimerFinishTime - DateTime.Now).TotalSeconds - _buffer;

                _sythesizer.Speak("Timer is now launched. Main time will finish in " + ((secondsTillFinish / 60 > 0) ? secondsTillFinish / 60 + "minutes, " : "") + secondsTillFinish % 60 + " seconds");
                return true;
            }
            else if (_pomodoroTimerStates == PomodoroTimerStates.BufferLaunched)
            {
                int secondsTillFinish = (int)(_pomodoroTimerFinishTime - DateTime.Now).TotalSeconds;
                _sythesizer.Speak("Timer is now launched. Buffer time will finish in " + ((secondsTillFinish / 60 > 0) ? secondsTillFinish / 60 + "minutes, " : "") + secondsTillFinish % 60 + " seconds");
                return true;
            }

            return false;
        }
        bool CheckIfNewStartIsNotAvailable()
        {
            if (DateTime.Now < _pomodoroTimerNextStartTime)
            {
                int secondsTillCanRestart = (int)(_pomodoroTimerNextStartTime - DateTime.Now).TotalSeconds;
                _sythesizer.Speak("You should still rest for "
                    + secondsTillCanRestart / 60 + "minutes, " + secondsTillCanRestart % 60 + " seconds");

                return true;
            }
            return false;
        }
        private void LaunchPomodoroTimer(int seconds)
        {
            if (CheckIfTimerLaunched()) return;

            if (CheckIfNewStartIsNotAvailable()) return;

            int timeSec = seconds;
            _buffer = timeSec / 4;


            _pomodoroTimerStates = PomodoroTimerStates.Launched;
            Delayed(timeSec, () =>
            {
                _pomodoroTimerStates = PomodoroTimerStates.BufferLaunched;
                _sythesizer.Speak("Main time finished. Left " + ((_buffer / 60 > 0) ? _buffer / 60 + " minutes, " : "") + (_buffer % 60) + " seconds");
                Delayed(_buffer, () =>
                {
                    _pomodoroTimerStates = PomodoroTimerStates.Stopped;
                    int restTime = timeSec / 2;
                    _sythesizer.Speak("Ready. Now - go activities, then change location, then mindfulness. ");
                    _pomodoroTimerNextStartTime = DateTime.Now.AddSeconds(restTime);

                    int secondsTillCanRestart = (int)(_pomodoroTimerNextStartTime - DateTime.Now).TotalSeconds;
                    _sythesizer.Speak("You should rest for "
                        + ((secondsTillCanRestart / 60 > 0) ? secondsTillCanRestart / 60 + "minutes ":"") + ((secondsTillCanRestart % 60 > 0) ? (secondsTillCanRestart % 60) + " seconds" : ""));
                    
                    Delayed(restTime, () =>
                    {
                        _sythesizer.Speak("OK. Now you can start new working session. Please, achieve the flow state!");
                        StopBrowserProcess();
                    });
                    LaunchVideoByLink("https://www.youtube.com/watch?v=XQuR1OxYJt0");
                    // Process.Start("https://www.youtube.com/watch?v=XQuR1OxYJt0");
                });
            }
            );
            _sythesizer.Speak("Timer for " + ((timeSec / 60 > 0) ? timeSec / 60 + "minutes, " : "") + ((timeSec % 60 > 0) ? (timeSec % 60) + " seconds" : "") + " launched."); 
            // _pomodoroTimerStartTime = DateTime.Now;
            _pomodoroTimerFinishTime = DateTime.Now.AddSeconds(timeSec + _buffer);
            

        }
        Process BrowserProcess = null;

        private void LaunchVideoByLink(string v)
        {
            BrowserProcess = Process.Start("firefox.exe", v);
            // chromiumWebBrowser1.LoadUrlAsync(v);
        }
        private void StopBrowserProcess()
        {
            KillProcess("firefox");
            //try
            //{
            //    BrowserProcess.Kill();
            //}
            //catch 
            //{

            //}
            //if(BrowserProcess!=null)
            //{
                
            //}
        }

        ////private void StopVideoInBrowser()
        ////{
        ////    try
        ////    {
        ////        Click("//*[@id=\"movie_player\"]");
        ////    }
        ////    catch (Exception)
        ////    {

        ////    }
        ////}

        //public  void Click(string xpath)
        //{
        //    (chromiumWebBrowser1 as IWebBrowser).EvaluateScriptAsync(
        //        string.Format("document.evaluate('{0}', document, null, XPathResult.ANY_TYPE, null).iterateNext().click();", xpath.Replace('\'', '\"')));

        //}
        private void LoadFormSettings()
        {
            sePomodoroPeriod.Value = Properties.Settings.Default.PomodoroPeriod;
        }
        
        private void tbLaunchNSDR_Click(object sender, EventArgs e)
        {
            string videoUrl = "https://www.youtube.com/watch?v=_noquwycq78";
            int prepareSeconds = 10;
            _sythesizer.Speak("You have " + prepareSeconds + " seconds to prepare for NSDR. Warm your hands. Lay down. After please make mindfulness practice.");
            
            if(!Debugger.IsAttached)Thread.Sleep(prepareSeconds*1000);

            RemoveDistractors();

            _sythesizer.Speak("NSDR Launched");
            LaunchVideoByLink(videoUrl);
            //System.Diagnostics.Process.Start(videoUrl);
            PeriodicTimer timer = new PeriodicTimer(
                120, 
                Utilities.GetVideoLengthSeconds(videoUrl) + 5,
                () =>
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
                },
                ()=> {
                    StopBrowserProcess();
                }
            );

            timer.Launch();
            
        }

        private void RemoveDistractors()
        {
            KillProcess("Telegram");
            KillProcess("Viber");
        }
        

        
        private void btPomodoro_Click(object sender, EventArgs e)
        {
            LaunchPomodoroTimer(Convert.ToInt32(sePomodoroPeriod.Value));
        }


        System.Windows.Forms.Timer _currentPomodoroTimer = null;
        public void Delayed(int delaySec, Action action)
        {
            _currentPomodoroTimer = new System.Windows.Forms.Timer();
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

            _hookCtrlShiftFOne.Dispose();
            _hookCtrlShiftFTwo.Dispose();
            _hookCtrlShiftFThree.Dispose();
            _hookCtrlShiftFFour.Dispose();
            _hookCtrlShiftFFive.Dispose();
            _hookCtrlShiftFTwelve.Dispose();
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();

            //CefShutdown();
        }

        private void btStopTimer_Click(object sender, EventArgs e)
        {
            if (_currentPomodoroTimer!=null && _currentPomodoroTimer.Enabled)
            {
                _currentPomodoroTimer.Stop();
                _pomodoroTimerStates = PomodoroTimerStates.Stopped;
                _sythesizer.Speak("Current timer stopped");
            }
            else
            {
                _sythesizer.Speak("Timer is not launched to be stopped. Hi hi hi");
            }
            
        }

        private void chromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }

    }
}
