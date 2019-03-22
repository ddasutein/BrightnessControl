using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Management; //add dll to reference
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;

namespace BrightnessControl
{
    public partial class MainWindow : Form
    {

        int LAST_BRIGHTNESS_VALUE;

        public MainWindow()
        {
            InitializeComponent();
            //SetBrightness(20);

            var brightnessValue = GetBrightness();
            label1.Text = brightnessValue.ToString();

            // Get the current brightness then save to integer 
            LAST_BRIGHTNESS_VALUE = GetBrightness();
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
                    foreach (ManagementObject mObj in objectCollection)
                    {
                        var br_obj = mObj.Properties["CurrentBrightness"].Value;
                        Debug.WriteLine("BRIGHTNESS_LEVEL" + br_obj);
                        int br = 0;
                        int.TryParse(br_obj + "", out br);
                        return br;
                        
                    }
                }
            }
            return 0;

        }

        public static byte[] ConvertInt32ToByteArray(Int32 I32)
        {
            return BitConverter.GetBytes(I32);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] bytes = ConvertInt32ToByteArray(LAST_BRIGHTNESS_VALUE);
            byte bytetest = bytes[0];
            SetBrightness(bytetest);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var brightnessValue = GetBrightness();
            label1.Text = brightnessValue.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            byte[] bytes = ConvertInt32ToByteArray(LAST_BRIGHTNESS_VALUE);
            byte bytetest = bytes[0];
            SetBrightness(bytetest);

            var brightnessValue = GetBrightness();
            label1.Text = brightnessValue.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int NEW_BRIGHTNESS_VALUE = int.Parse(textBox1.Text);
            byte[] bytes = ConvertInt32ToByteArray(NEW_BRIGHTNESS_VALUE);
            byte bytetest = bytes[0];
            SetBrightness(bytetest);

            var brightnessValue = GetBrightness();
            label1.Text = brightnessValue.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
