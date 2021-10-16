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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbLaunchNSDR = new System.Windows.Forms.Button();
            this.btPomodoro = new System.Windows.Forms.Button();
            this.sePomodoroPeriod = new DevExpress.XtraEditors.SpinEdit();
            this.btStopTimer = new System.Windows.Forms.Button();
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.sePomodoroPeriod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLaunchNSDR
            // 
            this.tbLaunchNSDR.Location = new System.Drawing.Point(249, 12);
            this.tbLaunchNSDR.Name = "tbLaunchNSDR";
            this.tbLaunchNSDR.Size = new System.Drawing.Size(163, 23);
            this.tbLaunchNSDR.TabIndex = 0;
            this.tbLaunchNSDR.Text = "NSDR";
            this.tbLaunchNSDR.UseVisualStyleBackColor = true;
            this.tbLaunchNSDR.Click += new System.EventHandler(this.tbLaunchPeriodicTimer_Click);
            // 
            // btPomodoro
            // 
            this.btPomodoro.Location = new System.Drawing.Point(280, 79);
            this.btPomodoro.Name = "btPomodoro";
            this.btPomodoro.Size = new System.Drawing.Size(173, 23);
            this.btPomodoro.TabIndex = 1;
            this.btPomodoro.Text = "Pomodoro Timer";
            this.btPomodoro.UseVisualStyleBackColor = true;
            this.btPomodoro.Click += new System.EventHandler(this.btPomodoro_Click);
            // 
            // sePomodoroPeriod
            // 
            this.sePomodoroPeriod.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sePomodoroPeriod.Location = new System.Drawing.Point(503, 81);
            this.sePomodoroPeriod.Name = "sePomodoroPeriod";
            this.sePomodoroPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePomodoroPeriod.Properties.Increment = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.sePomodoroPeriod.Properties.IsFloatValue = false;
            this.sePomodoroPeriod.Properties.MaskSettings.Set("mask", "N00");
            this.sePomodoroPeriod.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.sePomodoroPeriod.Size = new System.Drawing.Size(100, 20);
            this.sePomodoroPeriod.TabIndex = 2;
            // 
            // btStopTimer
            // 
            this.btStopTimer.Location = new System.Drawing.Point(334, 131);
            this.btStopTimer.Name = "btStopTimer";
            this.btStopTimer.Size = new System.Drawing.Size(75, 23);
            this.btStopTimer.TabIndex = 3;
            this.btStopTimer.Text = "Stop timer";
            this.btStopTimer.UseVisualStyleBackColor = true;
            this.btStopTimer.Click += new System.EventHandler(this.btStopTimer_Click);
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(26, 166);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(587, 248);
            this.chromiumWebBrowser1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 426);
            this.Controls.Add(this.chromiumWebBrowser1);
            this.Controls.Add(this.btStopTimer);
            this.Controls.Add(this.sePomodoroPeriod);
            this.Controls.Add(this.btPomodoro);
            this.Controls.Add(this.tbLaunchNSDR);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sePomodoroPeriod.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tbLaunchNSDR;
        private System.Windows.Forms.Button btPomodoro;
        private DevExpress.XtraEditors.SpinEdit sePomodoroPeriod;
        private System.Windows.Forms.Button btStopTimer;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
    }
}

