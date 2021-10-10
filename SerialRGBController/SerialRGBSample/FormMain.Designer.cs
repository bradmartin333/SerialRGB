namespace SerialRGBSample
{
    partial class FormMain
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
            this.btnManualCycle = new System.Windows.Forms.Button();
            this.serialRGBController = new SerialRGBController.SerialRGBController();
            this.SuspendLayout();
            // 
            // btnManualCycle
            // 
            this.btnManualCycle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualCycle.Location = new System.Drawing.Point(12, 184);
            this.btnManualCycle.Name = "btnManualCycle";
            this.btnManualCycle.Size = new System.Drawing.Size(145, 23);
            this.btnManualCycle.TabIndex = 1;
            this.btnManualCycle.Text = "Manual Cycle";
            this.btnManualCycle.UseVisualStyleBackColor = true;
            this.btnManualCycle.Click += new System.EventHandler(this.btnManualCycle_Click);
            // 
            // serialRGBController
            // 
            this.serialRGBController.Debug = true;
            this.serialRGBController.Location = new System.Drawing.Point(12, 12);
            this.serialRGBController.Name = "serialRGBController";
            this.serialRGBController.Size = new System.Drawing.Size(145, 114);
            this.serialRGBController.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 219);
            this.Controls.Add(this.btnManualCycle);
            this.Controls.Add(this.serialRGBController);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial RGB Sample";
            this.ResumeLayout(false);

        }

        #endregion

        private SerialRGBController.SerialRGBController serialRGBController;
        private System.Windows.Forms.Button btnManualCycle;
    }
}