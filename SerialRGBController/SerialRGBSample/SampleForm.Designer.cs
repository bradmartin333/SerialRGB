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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barR
            // 
            this.barR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barR.Location = new System.Drawing.Point(25, 47);
            this.barR.Maximum = 255;
            this.barR.Name = "barR";
            this.barR.Size = new System.Drawing.Size(199, 28);
            this.barR.TabIndex = 1;
            this.barR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SetScrollColor);
            // 
            // barG
            // 
            this.barG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barG.Location = new System.Drawing.Point(25, 75);
            this.barG.Maximum = 255;
            this.barG.Name = "barG";
            this.barG.Size = new System.Drawing.Size(199, 28);
            this.barG.TabIndex = 2;
            this.barG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SetScrollColor);
            // 
            // barB
            // 
            this.barB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barB.Location = new System.Drawing.Point(25, 103);
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
            this.BtnPickColor.Location = new System.Drawing.Point(28, 21);
            this.BtnPickColor.Name = "BtnPickColor";
            this.BtnPickColor.Size = new System.Drawing.Size(193, 23);
            this.BtnPickColor.TabIndex = 4;
            this.BtnPickColor.Text = "Pick Color";
            this.BtnPickColor.UseVisualStyleBackColor = false;
            this.BtnPickColor.Click += new System.EventHandler(this.BtnPickColor_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BtnPickColor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.barR, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.barB, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.barG, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 150);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 150);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SampleForm";
            this.Text = "SampleForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.HScrollBar barR;
        private System.Windows.Forms.HScrollBar barG;
        private System.Windows.Forms.HScrollBar barB;
        private System.Windows.Forms.Button BtnPickColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}