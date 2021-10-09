namespace HabitTimers
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLaunchPeriodicTimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLaunchPeriodicTimer
            // 
            this.tbLaunchPeriodicTimer.Location = new System.Drawing.Point(249, 12);
            this.tbLaunchPeriodicTimer.Name = "tbLaunchPeriodicTimer";
            this.tbLaunchPeriodicTimer.Size = new System.Drawing.Size(163, 23);
            this.tbLaunchPeriodicTimer.TabIndex = 0;
            this.tbLaunchPeriodicTimer.Text = "Launch Periodic Timer";
            this.tbLaunchPeriodicTimer.UseVisualStyleBackColor = true;
            this.tbLaunchPeriodicTimer.Click += new System.EventHandler(this.tbLaunchPeriodicTimer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 277);
            this.Controls.Add(this.tbLaunchPeriodicTimer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tbLaunchPeriodicTimer;
    }
}

