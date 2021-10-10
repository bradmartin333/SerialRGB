using System.IO.Ports;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Text;

namespace SerialRGBController
{
    public class Communication
    {
        public SerialPort Port;
        private readonly bool DEBUG = false;

        /// <summary>
        /// Initalize an Arduino communicator with optinal debug output
        /// </summary>
        /// <param name="DEBUG"></param>
        public Communication(bool DEBUG = false)
        {
            this.DEBUG = DEBUG;
            Port = new SerialPort
            {
                BaudRate = 115200,
                DataBits = 8,
                DiscardNull = false,
                DtrEnable = false,
                RtsEnable = true,
                Handshake = Handshake.None,
                ReadBufferSize = 4096,
                ReadTimeout = -1,
                WriteTimeout = -1,
                StopBits = StopBits.One
            };
            Port.DataReceived += Port_DataReceived;
        }

        /// <summary>
        /// Arduino will set the R G B channels together with a 10ms delay
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool SendColor(Color color)
        {
            try
            { 
                byte[] output = new byte[] { color.R, color.G, color.B };
                Port.Write(output, 0, 3);
                System.Threading.Thread.Sleep(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            string msg;
            msg = serialPort.ReadLine().Trim();
            if (DEBUG) Debug.WriteLine(msg);
        }

        public void UserControlScanPorts(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox.Items.Add(s);
            }
            comboBox.SelectedIndex = comboBox.Items.Count - 1;
            Port.PortName = comboBox.Text;
        }

        /// <summary>
        /// Search for ports and set active port to last port found
        /// </summary>
        public void FindPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            Port.PortName = ports[ports.Length - 1];
        }

        /// <summary>
        /// Connect to currently set PortName
        /// </summary>
        public void Connect()
        {
            try
            {
                Port.Open();
                Port.DtrEnable = true;
                System.Threading.Thread.Sleep(100);
                byte[] output = new byte[] { 0, 0, 0 };
                Port.Write(output, 0, 3);
                System.Threading.Thread.Sleep(250);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Disconnect and reset port
        /// </summary>
        public void Disconnect()
        {
            try
            {
                Port.Close();
                Port.DtrEnable = false;
                System.Threading.Thread.Sleep(250);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
