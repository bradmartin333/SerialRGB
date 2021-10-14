using System;
using System.Windows.Forms;

namespace SerialRGBSample
{
    partial class SampleForm
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.barR = new System.Windows.Forms.HScrollBar();
            this.barG = new System.Windows.Forms.HScrollBar();
            this.barB = new System.Windows.Forms.HScrollBar();
            this.BtnPickColor = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnCycleByHSL = new System.Windows.Forms.Button();
            this.btnCycleByWavelength = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // barR
            // 
            this.barR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barR.Location = new System.Drawing.Point(25, 40);
            this.barR.Maximum = 255;
            this.barR.Name = "barR";
            this.barR.Size = new System.Drawing.Size(199, 28);
            this.barR.TabIndex = 1;
            this.barR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SetScrollColor);
            // 
            // barG
            // 
            this.barG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barG.Location = new System.Drawing.Point(25, 68);
            this.barG.Maximum = 255;
            this.barG.Name = "barG";
            this.barG.Size = new System.Drawing.Size(199, 28);
            this.barG.TabIndex = 2;
            this.barG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SetScrollColor);
            // 
            // barB
            // 
            this.barB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barB.Location = new System.Drawing.Point(25, 96);
            this.barB.Maximum = 255;
            this.barB.Name = "barB";
            this.barB.Size = new System.Drawing.Size(199, 28);
            this.barB.TabIndex = 3;
            this.barB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SetScrollColor);
            // 
            // BtnPickColor
            // 
            this.BtnPickColor.BackColor = System.Drawing.Color.White;
            this.BtnPickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPickColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPickColor.Location = new System.Drawing.Point(28, 14);
            this.BtnPickColor.Name = "BtnPickColor";
            this.BtnPickColor.Size = new System.Drawing.Size(193, 23);
            this.BtnPickColor.TabIndex = 4;
            this.BtnPickColor.Text = "Pick Color";
            this.BtnPickColor.UseVisualStyleBackColor = false;
            this.BtnPickColor.Click += new System.EventHandler(this.BtnPickColor_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.BtnPickColor, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.barR, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.barB, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.barG, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.btnCycleByHSL, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.btnCycleByWavelength, 1, 7);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(250, 213);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // btnCycleByHSL
            // 
            this.btnCycleByHSL.BackColor = System.Drawing.Color.White;
            this.btnCycleByHSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCycleByHSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleByHSL.Location = new System.Drawing.Point(28, 147);
            this.btnCycleByHSL.Name = "btnCycleByHSL";
            this.btnCycleByHSL.Size = new System.Drawing.Size(193, 23);
            this.btnCycleByHSL.TabIndex = 5;
            this.btnCycleByHSL.Text = "Cycle by HSL";
            this.btnCycleByHSL.UseVisualStyleBackColor = false;
            this.btnCycleByHSL.Click += new System.EventHandler(this.btnCycleByHSL_Click);
            // 
            // btnCycleByWavelength
            // 
            this.btnCycleByWavelength.BackColor = System.Drawing.Color.White;
            this.btnCycleByWavelength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCycleByWavelength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleByWavelength.Location = new System.Drawing.Point(28, 176);
            this.btnCycleByWavelength.Name = "btnCycleByWavelength";
            this.btnCycleByWavelength.Size = new System.Drawing.Size(193, 23);
            this.btnCycleByWavelength.TabIndex = 6;
            this.btnCycleByWavelength.Text = "Cycle by Wavelength";
            this.btnCycleByWavelength.UseVisualStyleBackColor = false;
            this.btnCycleByWavelength.Click += new System.EventHandler(this.btnCycleByWavelength_Click);
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 213);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SampleForm";
            this.Text = "SampleForm";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.HScrollBar barR;
        private System.Windows.Forms.HScrollBar barG;
        private System.Windows.Forms.HScrollBar barB;
        private System.Windows.Forms.Button BtnPickColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Button btnCycleByHSL;
        private Button btnCycleByWavelength;
    }
}