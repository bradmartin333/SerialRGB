using System;
using System.Drawing;
using System.Windows.Forms;

namespace SerialRGBSample
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnManualCycle_Click(object sender, EventArgs e)
        {
            serialRGBController.Enabled = false;
            serialRGBController.btnPickColor.FlatAppearance.BorderColor = Color.Black;

            if (serialRGBController.Communication.Port.IsOpen)
                serialRGBController.Communication.Disconnect();

            serialRGBController.UpdateStatus();
            SerialRGBController.Communication communication= new SerialRGBController.Communication();
            communication.FindPorts();
            communication.Connect();

            for (double i = 0; i < 1; i += 0.01)
            {
                ColorRGB c = HSL2RGB(i, 0.5, 0.5);
                Color color = Color.FromArgb(c.R, c.G, c.B);
                btnManualCycle.BackColor = color;
                communication.SendColor(color);
                Application.DoEvents();
            }

            communication.SendColor(Color.Black);
            communication.Disconnect();
            btnManualCycle.BackColor = SystemColors.Control;
            serialRGBController.Enabled = true;
        }

        public struct ColorRGB
        {
            public byte R;
            public byte G;
            public byte B;

            public ColorRGB(Color value)
            {
                R = value.R;
                G = value.G;
                B = value.B;
            }

            public static implicit operator Color(ColorRGB rgb)
            { 
                Color c = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                return c;
            }

            public static explicit operator ColorRGB(Color c)
            {
                return new ColorRGB(c);
            }
        }

        // Given H,S,L in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static ColorRGB HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            ColorRGB rgb;
            rgb.R = Convert.ToByte(r * 255.0f);
            rgb.G = Convert.ToByte(g * 255.0f);
            rgb.B = Convert.ToByte(b * 255.0f);
            return rgb;
        }
    }
}
