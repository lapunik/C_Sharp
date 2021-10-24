using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OnOffMonitor
{
    public static class WinLowLevel
    {

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg,IntPtr wParam, IntPtr lParam);

         
        [DllImport("user32.dll")]
        public static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);


        private const int SC_MONITORPOWER = 0xF170;
        private const UInt32 WM_SYSCOMMAND = 0x0112;
        private const int MONITOR_ON = -1;
        private const int MONITOR_OFF = 2;
        private const int MONITOR_STANBY = 1;

        private const int MOUSEEVENTF_MOVE = 0x0001;


        public enum eMonitorState { On = -1, Off = 2, Standby = 1 };

        public static eMonitorState LastMonitorState = eMonitorState.On;
        // zaciname na ON

        public static void SetDisplayState(eMonitorState state)//, Window window)
        {
            var ret = SendMessage((IntPtr)0xffff /*wih.Handle*/,(uint) WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER,(IntPtr)state); //  (IntPtr)MONITOR_OFF);

            if (state == eMonitorState.On)
            {
                mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero);
            }
            //TODO update podle aktualniho stavu
            LastMonitorState = state;
        }

    }
}
