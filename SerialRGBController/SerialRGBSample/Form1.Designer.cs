﻿namespace SerialRGBSample
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
            this.serialRGBController1 = new SerialRGB.SerialRGBController();
            this.SuspendLayout();
            // 
            // serialRGBController1
            // 
            this.serialRGBController1.Location = new System.Drawing.Point(24, 21);
            this.serialRGBController1.Name = "serialRGBController1";
            this.serialRGBController1.Size = new System.Drawing.Size(145, 114);
            this.serialRGBController1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 153);
            this.Controls.Add(this.serialRGBController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial RGB Sample";
            this.ResumeLayout(false);

        }

        #endregion

        private SerialRGB.SerialRGBController serialRGBController1;
    }
}

