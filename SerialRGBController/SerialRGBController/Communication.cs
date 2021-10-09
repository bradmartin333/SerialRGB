using System.IO.Ports;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Drawing;

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
                BaudRate = 9600,
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
        /// Arduino will set the R G B channels individually with a small delay
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool SendColor(Color color)
        {
            try
            {
                Port.Write("R" + color.R.ToString());
                System.Threading.Thread.Sleep(100);
                Port.Write("G" + color.G.ToString());
                System.Threading.Thread.Sleep(100);
                Port.Write("B" + color.B.ToString());
                System.Threading.Thread.Sleep(100);
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
            msg = serialPort.ReadLine();
            MsgIn(msg);
        }

        private void MsgIn(string text)
        {
            string msg = text.Trim();
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
                Port.Write(" ");
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
                System.Threading.Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
