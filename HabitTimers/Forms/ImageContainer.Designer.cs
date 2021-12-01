namespace HabitTimers.Forms
{
    partial class ImageContainerForm
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.rtbDescr = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbInput.Location = new System.Drawing.Point(0, 0);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(800, 20);
            this.tbInput.TabIndex = 0;
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // rtbDescr
            // 
            this.rtbDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescr.Location = new System.Drawing.Point(0, 27);
            this.rtbDescr.Name = "rtbDescr";
            this.rtbDescr.ReadOnly = true;
            this.rtbDescr.Size = new System.Drawing.Size(245, 252);
            this.rtbDescr.TabIndex = 1;
            this.rtbDescr.Text = "";
            // 
            // ImageContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbDescr);
            this.Controls.Add(this.tbInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "ImageContainerForm";
            this.Text = "ImageContainer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageContainerForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.RichTextBox rtbDescr;
    }
}