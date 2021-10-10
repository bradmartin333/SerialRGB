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
        /// Arduino will set the R G B channels together with a small delay
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool SendColor(Color color)
        {
            try
            {
                string R = LuxToString(color.R);
                string G = LuxToString(color.G);
                string B = LuxToString(color.B);
                string output = string.Format("{0} {1} {2}", R, G, B);
                Port.Write(output);
                System.Threading.Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Converts a 0-255 number to a string of characters whose Dec value adds up to the number + 32
        /// The number 32 signifies a space and the space is used as a delimeter in the Port output
        /// </summary>
        /// <param name="lux"></param>
        /// <returns></returns>
        private string LuxToString(int lux)
        { 
            string output = string.Empty;
            lux += 32;
            while (true)
            {
                if (lux >= 126)
                {
                    output += Encoding.ASCII.GetString(new byte[] { 126 });
                    lux -= 126;
                }
                else if (lux >= 33)
                {
                    output += Encoding.ASCII.GetString(new byte[] { (byte)lux });
                    break;
                }
                else // Lux of 0
                    break;
            }
            return output;
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
