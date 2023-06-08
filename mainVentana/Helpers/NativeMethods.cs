using System;
using System.Runtime.InteropServices;

namespace mainVentana.Helpers
{
    public class NativeMethods
    {
       // [DllImport("user32.dll")]
        //public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, IntPtr prcScroll, IntPtr prcClip, IntPtr hrgnUpdate, IntPtr prcUpdate, uint flags);

        public const int WM_SETREDRAW = 0x000B;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
    }
}
