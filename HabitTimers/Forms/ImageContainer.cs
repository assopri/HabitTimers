using AUtilities;
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

namespace HabitTimers.Forms
{
    public partial class ImageContainerForm : Form
    {
        public ImageContainerForm(string caption, string description)
        {
            InitializeComponent();

            string rootImageFolderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "images"); //, "noimage.jpg"
            string specificImageFolderPath = Path.Combine(rootImageFolderPath, caption);
            if (!Directory.Exists(specificImageFolderPath)) Directory.CreateDirectory(specificImageFolderPath);
            string randomFile = Utilities.GetRandomFileFromFolder(specificImageFolderPath);
            if (!String.IsNullOrEmpty(randomFile))
            {
                Bitmap bpm = new Bitmap(randomFile);
                this.BackgroundImage = bpm;
            }
            
            this.Text = caption;
            rtbDescr.Text = description.Trim();

            tbInput.Focus();
        }


        private void ImageContainerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            if (tbInput.Text.Trim().ToLower() == this.Text.ToLower().Trim() ||
                StringUtilities.ConvertEngToRus(tbInput.Text.Trim().ToLower()) ==
                 this.Text.ToLower().Trim()) this.Close();
        }
    }
}
