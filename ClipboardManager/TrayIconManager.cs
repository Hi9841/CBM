using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClipboardManager
{
    public class TrayIconManager : IDisposable
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _menu;
        public event EventHandler ShowClicked = delegate { };
        public event EventHandler ClearAllClicked = delegate { };
        public event EventHandler ExitClicked = delegate { };

        public TrayIconManager()
        {
            _menu = new ContextMenuStrip();
            var showItem = new ToolStripMenuItem("Show");
            var clearAllItem = new ToolStripMenuItem("Clear All");
            var exitItem = new ToolStripMenuItem("Exit");
            _menu.Items.AddRange(new ToolStripItem[] { showItem, clearAllItem, exitItem });

            showItem.Click += (s, e) => ShowClicked?.Invoke(this, EventArgs.Empty);
            clearAllItem.Click += (s, e) => ClearAllClicked?.Invoke(this, EventArgs.Empty);
            exitItem.Click += (s, e) => ExitClicked?.Invoke(this, EventArgs.Empty);

            _notifyIcon = new NotifyIcon
            {
                Icon = CreateTrayIcon(),
                Text = "Clipboard Manager",
                Visible = true,
                ContextMenuStrip = _menu
            };
            _notifyIcon.DoubleClick += (s, e) => ShowClicked?.Invoke(this, EventArgs.Empty);
        }

        private Icon CreateTrayIcon()
        {
            // Draw a simple clipboard icon (black/white)
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Pen pen = new Pen(Color.White, 2))
                {
                    g.DrawRectangle(pen, 3, 4, 10, 8); // clipboard body
                    g.DrawRectangle(pen, 5, 2, 6, 3); // clipboard top
                }
            }
            return Icon.FromHandle(bmp.GetHicon());
        }

        public void ShowBalloon(string title, string text)
        {
            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = text;
            _notifyIcon.ShowBalloonTip(2000);
        }

        public void Dispose()
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            _menu.Dispose();
        }
    }
} 