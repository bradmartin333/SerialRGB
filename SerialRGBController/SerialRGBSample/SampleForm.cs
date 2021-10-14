using System;
using System.Drawing;
using System.Windows.Forms;

namespace SerialRGBSample
{
    public partial class SampleForm : Form
    {
        readonly SerialRGBController.Communication Communication = new SerialRGBController.Communication("COM3");
        bool UpdatingScroll = false;

        public SampleForm()
        {
            InitializeComponent();
        }

        private void BtnPickColor_Click(object sender, EventArgs e)
        {
            Color color = Color.Black;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                color = colorDialog.Color;
            if (Communication.SendColor(colorDialog.Color))
                BackColor = color;
            else
                BackColor = Color.Black;
            UpdatingScroll = true;
            barR.Value = color.R;
            barG.Value = color.G;
            barB.Value = color.B;
            UpdatingScroll = false;
        }

        private void SetScrollColor(object sender, ScrollEventArgs e)
        {
            if (UpdatingScroll) return;
            UpdatingScroll = true;
            Color color = Color.FromArgb(barR.Value, barG.Value, barB.Value);
            if (Communication.SendColor(color))
                BackColor = color;
            else
                BackColor = Color.Black;
            UpdatingScroll = false;
        }
    }
}
