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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btStopTimer = new System.Windows.Forms.Button();
            this.sePomodoroPeriod = new DevExpress.XtraEditors.SpinEdit();
            this.btPomodoro = new System.Windows.Forms.Button();
            this.tbLaunchNSDR = new System.Windows.Forms.Button();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sePomodoroPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btStopTimer);
            this.layoutControl1.Controls.Add(this.sePomodoroPeriod);
            this.layoutControl1.Controls.Add(this.btPomodoro);
            this.layoutControl1.Controls.Add(this.tbLaunchNSDR);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(705, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(648, 133);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "lcMain";
            // 
            // btStopTimer
            // 
            this.btStopTimer.Location = new System.Drawing.Point(12, 69);
            this.btStopTimer.Name = "btStopTimer";
            this.btStopTimer.Size = new System.Drawing.Size(624, 24);
            this.btStopTimer.TabIndex = 8;
            this.btStopTimer.Text = "Stop timer";
            this.btStopTimer.UseVisualStyleBackColor = true;
            this.btStopTimer.Click += new System.EventHandler(this.btStopTimer_Click);
            // 
            // sePomodoroPeriod
            // 
            this.sePomodoroPeriod.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sePomodoroPeriod.Location = new System.Drawing.Point(105, 12);
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
            this.sePomodoroPeriod.Size = new System.Drawing.Size(531, 20);
            this.sePomodoroPeriod.StyleController = this.layoutControl1;
            this.sePomodoroPeriod.TabIndex = 7;
            // 
            // btPomodoro
            // 
            this.btPomodoro.Location = new System.Drawing.Point(12, 36);
            this.btPomodoro.Name = "btPomodoro";
            this.btPomodoro.Size = new System.Drawing.Size(624, 29);
            this.btPomodoro.TabIndex = 6;
            this.btPomodoro.Text = "Pomodoro Timer";
            this.btPomodoro.UseVisualStyleBackColor = true;
            this.btPomodoro.Click += new System.EventHandler(this.btPomodoro_Click);
            // 
            // tbLaunchNSDR
            // 
            this.tbLaunchNSDR.Location = new System.Drawing.Point(12, 97);
            this.tbLaunchNSDR.Name = "tbLaunchNSDR";
            this.tbLaunchNSDR.Size = new System.Drawing.Size(624, 24);
            this.tbLaunchNSDR.TabIndex = 5;
            this.tbLaunchNSDR.Text = "NSDR";
            this.tbLaunchNSDR.UseVisualStyleBackColor = true;
            this.tbLaunchNSDR.Click += new System.EventHandler(this.tbLaunchPeriodicTimer_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(648, 133);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btStopTimer;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 57);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(628, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.sePomodoroPeriod;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(628, 24);
            this.layoutControlItem3.Text = "Pomorodo period";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btPomodoro;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(628, 33);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.tbLaunchNSDR;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 85);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(628, 28);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 133);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sePomodoroPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.Button btStopTimer;
        private DevExpress.XtraEditors.SpinEdit sePomodoroPeriod;
        private System.Windows.Forms.Button btPomodoro;
        private System.Windows.Forms.Button tbLaunchNSDR;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}

