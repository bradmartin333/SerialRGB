using System.IO.Ports;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace SerialRGB
{
    class Communication
    {
        public SerialPort Port;
        public Communication()
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
        }

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
            Debug.WriteLine(msg);
        }

        public void ScanPorts(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox.Items.Add(s);
            }
            comboBox.SelectedIndex = comboBox.Items.Count - 1;
            Port.PortName = comboBox.Text;
        }

        public void Connect()
        {
            try
            {
                Port.Open();
                System.Threading.Thread.Sleep(100);
                Port.Write(" ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
