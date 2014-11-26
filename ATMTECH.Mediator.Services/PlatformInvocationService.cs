using System;
using System.Runtime.InteropServices;

namespace ATMTECH.Mediator.Services
{
    public class PlatformInvocationService
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        public static bool IsActive(IntPtr handle)
        {
            IntPtr activeHandle = GetForegroundWindow();
            return (activeHandle == handle);
        }
    }
}
