using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrightnessControl.Monitor
{
    public class BrightnessController
    {
        public static IntPtr Handle { get; private set; }

        public static void StartController(string apihandler)
        {
            switch (apihandler)
            {
                case "wmi":
                    MessageBox.Show("Using WMI to Control Brightness");
                    break;
                case "win32":
                    MessageBox.Show("Using Win32/DDC to control brightness");
                    break;
                default:
                    break;
            }
        }
    }
}
