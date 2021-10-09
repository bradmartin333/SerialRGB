using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SerialRGB
{
    public partial class SerialRGBController : UserControl
    {
        [
            Description("Application will try to automatically connect to first appropriate COM port"),
            Category("Data")
        ]

        private readonly Communication Communication;

        public SerialRGBController()
        {
            InitializeComponent();
            Name = "SerialRGBController";
            Communication = new Communication();
            Communication.ScanPorts(comboBox);
            Disposed += Controller_Disposed;
        }

        private void Controller_Disposed(object sender, EventArgs e)
        {
            Communication.Port.Close();
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            Color color = Color.Black;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                color = colorDialog.Color;
            if (Communication.SendColor(colorDialog.Color))
                btnPickColor.FlatAppearance.BorderColor = color;
            else
                btnPickColor.FlatAppearance.BorderColor = Color.Black;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectAndUpdateStatus();
        }

        private void ConnectAndUpdateStatus()
        {
            Communication.Connect();
            if (Communication.Port.IsOpen)
            {
                btnConnect.FlatAppearance.BorderColor = Color.Green;
                btnConnect.Text = "Connected";
                comboBox.Enabled = false;
            }
            else
            {
                btnConnect.FlatAppearance.BorderColor = Color.Red;
                btnConnect.Text = "Error";
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Communication.Port.PortName = comboBox.Text;
        }
    }
}
