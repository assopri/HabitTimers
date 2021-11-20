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

namespace HabitTimers.Forms
{
    public partial class ImageContainerForm : Form
    {
        public ImageContainerForm(string path, string caption)
        {
            InitializeComponent();

            Bitmap bpm = new Bitmap(path);
            this.BackgroundImage = bpm;
            this.Size = bpm.Size;
            this.Text = caption;
        }
    }
}
