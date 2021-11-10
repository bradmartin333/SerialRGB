using System.IO.Ports;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Diagnostics;

namespace SerialRGBController
{
    public class Communication
    {
        public SerialPort Port;

        /// <summary>
        /// Initalize an Arduino communicator with optinal debug output
        /// </summary>
        public Communication(string PortName = null)
        {
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
            if (PortName != null) Connect(PortName);
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

        /// <summary>
        /// Connect to currently set PortName
        /// </summary>
        public void Connect(string portName)
        {
            try
            {
                Port.PortName = portName;
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

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            Debug.WriteLine(serialPort.ReadLine().Trim());
        }
    }
}
