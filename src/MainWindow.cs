using System;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrightnessControl.Monitor;


namespace BrightnessControl
{



    public partial class MainWindow : Form
    {

        // Global variables
        int LAST_BRIGHTNESS_VALUE;
        MonitorManagement[] bc;
        public MainWindow()
        {
            InitializeComponent();
            scanScreen();
            
            // Save the current brightness value in memory 
            //LAST_BRIGHTNESS_VALUE = GetBrightness();
            //LastKnownBrightnessValue.Text = LAST_BRIGHTNESS_VALUE.ToString();
        }

        //static void SetBrightness(byte targetBrightness)
        //{
        //    ManagementScope scope = new ManagementScope("root\\WMI");
        //    SelectQuery query = new SelectQuery("WmiMonitorBrightnessMethods");
        //    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
        //    {
        //        using (ManagementObjectCollection objectCollection = searcher.Get())
        //        {
        //            foreach (ManagementObject mObj in objectCollection)
        //            {
        //                mObj.InvokeMethod("WmiSetBrightness",
        //                    new Object[] { UInt32.MaxValue, targetBrightness });

        //                Debug.WriteLine("SET_BRIGHTNESS " + targetBrightness);
        //                break;
        //            }
        //        }
        //    }
        //}

        //private int GetBrightness()
        //{
        //    ManagementScope scope = new ManagementScope("root\\WMI");
        //    SelectQuery query = new SelectQuery("WmiMonitorBrightness");
        //    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
        //    {
        //        using (ManagementObjectCollection objectCollection = searcher.Get())
        //        {
        //            try
        //            {
        //                foreach (ManagementObject mObj in objectCollection)
        //                {
        //                    var brightnessObject = mObj.Properties["CurrentBrightness"].Value;
        //                    int brightness = 0;
        //                    int.TryParse(brightnessObject + "", out brightness);

        //                    Debug.WriteLine("GET_BRIGHTNESS " + brightnessObject);
        //                    return brightness;

        //                }

        //            }catch(ManagementException e)
        //            {
        //                MessageBox.Show("DDC/CI not supported on this monitor.");
        //                this.BrightnessValueLabel.Text = "Not Supported";
                        
        //            }
        //        }
        //    }
        //    return 0;

        //}

        //public static byte[] ConvertInt32ToByteArray(Int32 I32)
        //{
        //    return BitConverter.GetBytes(I32);
        //}

        //private void ReturnOriginalBrightness()
        //{
        //    byte[] lastBrightnessByteArray = ConvertInt32ToByteArray(LAST_BRIGHTNESS_VALUE);
        //    byte lastBrightnessByte = lastBrightnessByteArray[0];
        //    SetBrightness(lastBrightnessByte);
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ReturnOriginalBrightness();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //var brightnessValue = GetBrightness();
            //BrightnessValueLabel.Text = brightnessValue.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //ReturnOriginalBrightness();
            //var brightnessValue = GetBrightness();
            //BrightnessValueLabel.Text = brightnessValue.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            //int NEW_BRIGHTNESS_VALUE = int.Parse(textBox1.Text);
            //byte[] newBrightnessByteArray = ConvertInt32ToByteArray(NEW_BRIGHTNESS_VALUE);
            //byte newBrightnessByte = newBrightnessByteArray[0];
            //SetBrightness(newBrightnessByte);

            //var brightnessValue = GetBrightness();
            //BrightnessValueLabel.Text = brightnessValue.ToString();
            //bc[0].SetBrightness(100);
            //var t = BrightnessController.bc[0].getBrightnessStat();
            //Debug.WriteLine(t[1]);
            MessageBox.Show(DDCCIMonitor.GetBrightness());
            DDCCIMonitor.SetBrightness(100);
        }

        private void scanScreen()
        {
            //List<MonitorManagement> bc_temp = new List<MonitorManagement>();
            //MonitorManagement temp = null;
            //temp = new MonitorManagement(Handle);
            //var t = temp.checkMonitorSupport();
            ////bc_temp.Add(temp);
            //MessageBox.Show(t.ToString());
            //int num = 0;


            BrightnessManagement.CheckSupport();

            if (!BrightnessManagement.IsWMISupported && !BrightnessManagement.IsWin32Supported)
            {
                button4.Enabled = false;
            }
            //bc = bc_temp.ToArray();


            //Debug.WriteLine("BC_TEMP: " + bc);
            //Debug.WriteLine("BC: " + bc[num].getBrightnessStat());

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BrightnessDialog bd = new BrightnessDialog();
            bd.Show();
        }
    }


    //

}
