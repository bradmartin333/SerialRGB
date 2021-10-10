using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SerialRGBController
{
    public partial class SerialRGBController : UserControl
    {
        [
            Description("Application will try to automatically connect to first appropriate COM port"),
            Category("Data")
        ]
        public bool Debug { get; set; } = false;

        public Communication Communication;
        
        /// <summary>
        /// User Control for simple communication
        /// </summary>
        public SerialRGBController()
        {
            InitializeComponent();
        }

        private void SerialRGBController_Load(object sender, EventArgs e)
        {
            Communication = new Communication(Debug);
            Communication.UserControlScanPorts(comboBox);
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
            Communication.Connect();
            UpdateStatus();
        }

        /// <summary>
        /// Check for communication port and update button status
        /// </summary>
        public void UpdateStatus()
        {
            if (Communication.Port.IsOpen)
            {
                btnConnect.FlatAppearance.BorderColor = Color.Green;
                btnConnect.Text = "Connected";
                comboBox.Enabled = false;
            }
            else
            {
                btnConnect.FlatAppearance.BorderColor = Color.Black;
                btnConnect.Text = "Connect";
            }
            Application.DoEvents();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Communication.Port.PortName = comboBox.Text;
        }
    }
}
