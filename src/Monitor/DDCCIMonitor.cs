using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightnessControl.Monitor
{
    public class DDCCIMonitor
    {
        public static MonitorManagement[] bc;
        public static List<MonitorManagement> bc_temp = new List<MonitorManagement>();

        public static IntPtr Handle { get; private set; }

        private static MonitorManagement monitorManagement = new MonitorManagement(Handle);

        public static void CheckDDC()
        {
            monitorManagement.CheckMonitorSupport();

            if (monitorManagement.CheckMonitorSupport())
            {
                MonitorManagement temp = new MonitorManagement(Handle);
                bc_temp.Add(temp);
                bc = bc_temp.ToArray();
                Debug.WriteLine("BC: " + bc);
            }
        }
    
        public static string GetBrightness()
        {
            uint[] brightnessValue = bc[0].getBrightnessStat();
            return brightnessValue[1].ToString();
        }

        public static void SetBrightness(int value)
        {
            bc[0].SetBrightness(value);
        }
    }
}
