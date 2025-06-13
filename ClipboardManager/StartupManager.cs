using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace ClipboardManager
{
    public static class StartupManager
    {
        private const string RunKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string AppName = "ClipboardManager";

        public static void EnsureStartup()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKey, true))
                {
                    string exePath = Process.GetCurrentProcess().MainModule.FileName;
                    object value = key.GetValue(AppName);
                    if (value == null || !string.Equals(value.ToString(), '"' + exePath + '"', StringComparison.OrdinalIgnoreCase))
                    {
                        key.SetValue(AppName, '"' + exePath + '"');
                    }
                }
            }
            catch (Exception)
            {
                // Ignore errors (user may not have permission)
            }
        }

        public static void RemoveStartup()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKey, true))
                {
                    key.DeleteValue(AppName, false);
                }
            }
            catch (Exception)
            {
                // Ignore errors
            }
        }
    }
} 