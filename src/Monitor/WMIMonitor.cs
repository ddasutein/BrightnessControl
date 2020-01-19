using System;
using System.Management;

namespace BrightnessControl.Monitor
{
    public class WMIMonitor
    {
        private static readonly ManagementScope scope = new ManagementScope("root\\WMI");
        private static readonly SelectQuery queryWmiMonitorBrightness = new SelectQuery("WmiMonitorBrightness");
        private static readonly SelectQuery queryWmiMonitorBrightnessMethods = new SelectQuery("WmiMonitorBrightnessMethods");

        public static void CheckWMI()
        {
            GetBrightness();
        }

        public static int GetBrightness()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, queryWmiMonitorBrightness))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    try
                    {
                        foreach (ManagementObject mObj in objectCollection)
                        {
                            BrightnessManagement.IsWMISupported = true;
                            return Convert.ToInt32(mObj.Properties["CurrentBrightness"].Value);
                        }
                    }
                    catch (ManagementException e)
                    {
                        BrightnessManagement.IsWMISupported = false;
                    }
                }
            }
            return 0;
        }
    }
}
