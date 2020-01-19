using System.Diagnostics;

namespace BrightnessControl.Monitor
{
    public class BrightnessManagement
    {
        public static bool IsWMISupported;
        public static bool IsWin32Supported;

        public static void CheckSupport()
        {
            WMIMonitor.CheckWMI();

            if (!IsWMISupported)
            {
                Debug.WriteLine("WMI not supported. Checking Win32 support");

                DDCCIMonitor.CheckDDC();

                if (!IsWin32Supported)
                {
                    Debug.WriteLine("Win32 not supported");

                    if (!IsWin32Supported && !IsWMISupported)
                    {
                        Debug.WriteLine("Unable to control brightness with WMI or Win32");
                    }

                } else
                {
                    BrightnessController.StartController("win32");
                }

            } 
            else
            {
                BrightnessController.StartController("wmi");
            }

        }
    }
}
