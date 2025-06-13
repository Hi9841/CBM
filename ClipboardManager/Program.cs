using System;
using System.Threading;
using System.Windows.Forms;

namespace ClipboardManager
{
    internal static class Program
    {
        // Mutex to ensure single instance
        private static Mutex mutex = new Mutex(true, "ClipboardManager_SingleInstanceMutex");

        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                // App is already running
                MessageBox.Show("Clipboard Manager is already running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ensure app starts with Windows
            StartupManager.EnsureStartup();

            // Run main form
            Application.Run(new MainForm());

            mutex.ReleaseMutex();
        }
    }
} 