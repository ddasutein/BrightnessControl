using System;
using System.Runtime.InteropServices;

namespace BrightnessControl.Monitor
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PHYSICAL_MONITOR
    {
        public IntPtr hPhysicalMonitor;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szPhysicalMonitorDescription;
    }

    public class MonitorManagement : IDisposable
    {
        #region Win32
        [DllImport("user32.dll", EntryPoint = "MonitorFromWindow")]
        public static extern IntPtr MonitorFromWindow([In] IntPtr hwnd, uint dwFlags);

        [DllImport("dxva2.dll", EntryPoint = "DestroyPhysicalMonitors")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyPhysicalMonitors(uint dwPhysicalMonitorArraySize, ref PHYSICAL_MONITOR[] pPhysicalMonitorArray);

        [DllImport("dxva2.dll", EntryPoint = "GetNumberOfPhysicalMonitorsFromHMONITOR")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, ref uint pdwNumberOfPhysicalMonitors);

        [DllImport("dxva2.dll", EntryPoint = "GetPhysicalMonitorsFromHMONITOR")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint dwPhysicalMonitorArraySize, [Out] PHYSICAL_MONITOR[] pPhysicalMonitorArray);

        [DllImport("dxva2.dll", EntryPoint = "GetMonitorBrightness")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorBrightness(IntPtr handle, ref uint minimumBrightness, ref uint currentBrightness, ref uint maxBrightness);

        [DllImport("dxva2.dll", EntryPoint = "SetMonitorBrightness")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetMonitorBrightness(IntPtr handle, uint newBrightness);
        #endregion

        private uint _physicalMonitorsCount = 0;
        private PHYSICAL_MONITOR[] _physicalMonitorArray;

        private IntPtr _currentMonitorHandle;

        private uint _minValue = 0;
        private uint _maxValue = 0;
        private uint _currentValue = 0;

        private IntPtr windowHandle_last;

        public bool CheckMonitorSupport()
        {
            if (!GetMonitorBrightness(_currentMonitorHandle, ref _minValue, ref _currentValue, ref _maxValue))
            {
                BrightnessManagement.IsWin32Supported = false;
                return false;
            }
            else
            {
                BrightnessManagement.IsWin32Supported = true;
                return true;
            }
        }

        public uint[] SetMonitor()
        {
            uint dwFlags = 2u;
            IntPtr ptr = MonitorFromWindow(windowHandle_last, dwFlags);
            if (!GetNumberOfPhysicalMonitorsFromHMONITOR(ptr, ref _physicalMonitorsCount))
            {
                //MessageBox.Show("Cannot get monitor count!", "Brightness Controller");
                throw new Exception("Cannot get monitor count!");
            }
            _physicalMonitorArray = new PHYSICAL_MONITOR[_physicalMonitorsCount];

            if (!GetPhysicalMonitorsFromHMONITOR(ptr, _physicalMonitorsCount, _physicalMonitorArray))
            {
                //MessageBox.Show("Cannot get physical monitor handle!", "Brightness Controller");
                throw new Exception("Cannot get physical monitor handle!");
            }
            _currentMonitorHandle = _physicalMonitorArray[0].hPhysicalMonitor;

            if (!GetMonitorBrightness(_currentMonitorHandle, ref _minValue, ref _currentValue, ref _maxValue))
            {
                //MessageBox.Show("Cannot get monitor brightness!", "Brightness Controller");
                throw new Exception("Cannot get monitor brightness!");
            }
            return getBrightnessStat();
        }

        public uint[] getBrightnessStat()
        {
            GetMonitorBrightness(_currentMonitorHandle, ref _minValue, ref _currentValue, ref _maxValue);
            uint[] brightnessStat = { _minValue, _currentValue, _maxValue };
            return brightnessStat;
        }

        public MonitorManagement(IntPtr windowHandle)
        {
            windowHandle_last = windowHandle;
            uint dwFlags = 2u;
            IntPtr ptr = MonitorFromWindow(windowHandle, dwFlags);
            if (!GetNumberOfPhysicalMonitorsFromHMONITOR(ptr, ref _physicalMonitorsCount))
            {
                //MessageBox.Show("Cannot get monitor count!", "Brightness Controller");
                throw new Exception("Cannot get monitor count!");
            }
            _physicalMonitorArray = new PHYSICAL_MONITOR[_physicalMonitorsCount];

            if (!GetPhysicalMonitorsFromHMONITOR(ptr, _physicalMonitorsCount, _physicalMonitorArray))
            {
               // MessageBox.Show("Cannot get phisical monitor handle!", "Brightness Controller");
                throw new Exception("Cannot get phisical monitor handle!");
            }
            _currentMonitorHandle = _physicalMonitorArray[0].hPhysicalMonitor;

            // Hard Code fix The ERROR_01
            //if (!GetMonitorBrightness(_currentMonitorHandle, ref _minValue, ref _currentValue, ref _maxValue))
            //{
            //    MessageBox.Show("Cannot get monitor brightness!", "Brightness Controller");
            //    throw new Exception("Cannot get monitor brightness!");
            //}
        }

        public void SetBrightness(int newValue)
        {
            newValue = Math.Min(newValue, Math.Max(0, newValue));
            _currentValue = (_maxValue - _minValue) * (uint)newValue / 100u + _minValue;
            SetMonitorBrightness(_currentMonitorHandle, _currentValue);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_physicalMonitorsCount > 0)
                {
                    DestroyPhysicalMonitors(_physicalMonitorsCount, ref _physicalMonitorArray);
                }
            }
        }
    }
}
