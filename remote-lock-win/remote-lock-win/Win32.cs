using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace remote_lock_win
{
    public class Win32
    {
        private static void Call(Func<bool> callback)
        {
            if (callback())
                return;

            throw Marshal.GetExceptionForHR(Marshal.GetLastWin32Error());
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWorkStation();

        public static void LockSession() => Call(LockWorkStation);
    }
}
