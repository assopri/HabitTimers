using HabitTimers.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabitTimers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LaunchPeriodicTimer(3);
        }

        private void tbLaunchPeriodicTimer_Click(object sender, EventArgs e)
        {
            LaunchPeriodicTimer(3);
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


        //private void LaunchPeriodicTimer
    }
}
