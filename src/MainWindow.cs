using System;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;

namespace BrightnessControl
{
    public partial class MainWindow : Form
    {

        // Global variables
        int LAST_BRIGHTNESS_VALUE;

        public MainWindow()
        {
            InitializeComponent();

            // Save the current brightness value in memory 
            LAST_BRIGHTNESS_VALUE = GetBrightness();
            LastKnownBrightnessValue.Text = LAST_BRIGHTNESS_VALUE.ToString();
        }

        static void SetBrightness(byte targetBrightness)
        {
            ManagementScope scope = new ManagementScope("root\\WMI");
            SelectQuery query = new SelectQuery("WmiMonitorBrightnessMethods");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    foreach (ManagementObject mObj in objectCollection)
                    {
                        mObj.InvokeMethod("WmiSetBrightness",
                            new Object[] { UInt32.MaxValue, targetBrightness });

                        Debug.WriteLine("SET_BRIGHTNESS " + targetBrightness);
                        break;
                    }
                }
            }
        }

        static int GetBrightness()
        {
            ManagementScope scope = new ManagementScope("root\\WMI");
            SelectQuery query = new SelectQuery("WmiMonitorBrightness");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    try
                    {
                        foreach (ManagementObject mObj in objectCollection)
                        {
                            var brightnessObject = mObj.Properties["CurrentBrightness"].Value;
                            int brightness = 0;
                            int.TryParse(brightnessObject + "", out brightness);

                            Debug.WriteLine("GET_BRIGHTNESS " + brightnessObject);
                            return brightness;

                        }

                    }catch (ManagementException e)
                    {
                        MessageBox.Show("DDC/CI not supported on this monitor.");
                    }
                }
            }
            return 0;

        }

        public static byte[] ConvertInt32ToByteArray(Int32 I32)
        {
            return BitConverter.GetBytes(I32);
        }

        private void ReturnOriginalBrightness()
        {
            byte[] lastBrightnessByteArray = ConvertInt32ToByteArray(LAST_BRIGHTNESS_VALUE);
            byte lastBrightnessByte = lastBrightnessByteArray[0];
            SetBrightness(lastBrightnessByte);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReturnOriginalBrightness();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var brightnessValue = GetBrightness();
            BrightnessValueLabel.Text = brightnessValue.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ReturnOriginalBrightness();
            var brightnessValue = GetBrightness();
            BrightnessValueLabel.Text = brightnessValue.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            int NEW_BRIGHTNESS_VALUE = int.Parse(textBox1.Text);
            byte[] newBrightnessByteArray = ConvertInt32ToByteArray(NEW_BRIGHTNESS_VALUE);
            byte newBrightnessByte = newBrightnessByteArray[0];
            SetBrightness(newBrightnessByte);

            var brightnessValue = GetBrightness();
            BrightnessValueLabel.Text = brightnessValue.ToString();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int NEW_BRIGHTNESS_VALUE = int.Parse(textBox1.Text);
            byte[] newBrightnessByteArray = ConvertInt32ToByteArray(NEW_BRIGHTNESS_VALUE);
            byte newBrightnessByte = newBrightnessByteArray[0];
            SetBrightness(newBrightnessByte);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
