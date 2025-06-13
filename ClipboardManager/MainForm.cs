using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using System.Linq.Expressions;

namespace ClipboardManager
{
    public partial class MainForm : Form
    {
        private readonly ClipboardHistory _history = new ClipboardHistory();
        private readonly TrayIconManager _trayIcon;
        private HotkeyManager? _hotkeyManager;
        private Keys _screenshotHotkey = Keys.Control | Keys.P;
        private HistoryPage _historyPage;
        private KeybindsPage _keybindsPage;

        public MainForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
            _historyPage = new HistoryPage(_history);
            _keybindsPage = new KeybindsPage();
            _keybindsPage.KeybindChanged += OnKeybindChanged;
            contentPanel.Controls.Add(_historyPage);
            contentPanel.Controls.Add(_keybindsPage);
            _historyPage.Dock = DockStyle.Fill;
            _keybindsPage.Dock = DockStyle.Fill;
            ShowPage(_historyPage);

            btnHistory.Click += (s, e) => ShowPage(_historyPage);
            btnKeybinds.Click += (s, e) => ShowPage(_keybindsPage);

            // Tray icon
            _trayIcon = new TrayIconManager();
            _trayIcon.ShowClicked += (s, e) => ShowFromTray();
            _trayIcon.ClearAllClicked += (s, e) => _history.Clear();
            _trayIcon.ExitClicked += (s, e) => { _trayIcon.Dispose(); Application.Exit(); };

            this.FormClosing += MainForm_FormClosing;
            this.Resize += MainForm_Resize;
            this.Load += MainForm_Load;
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Hide to tray instead of closing
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                HideToTray();
            }
        }

        private void MainForm_Resize(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideToTray();
            }
        }

        private void HideToTray()
        {
            this.Hide();
            _trayIcon.ShowBalloon("Clipboard Manager", "App is running in the background.");
        }

        private void ShowFromTray()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private string Truncate(string? text, int max)
        {
            if (string.IsNullOrEmpty(text)) return text ?? string.Empty;
            return text.Length > max ? text.Substring(0, max) + "..." : text;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            _hotkeyManager = new HotkeyManager(this.Handle);
            _hotkeyManager.HotkeyPressed += (s, ev) => CaptureScreenshot();
            _hotkeyManager.RegisterHotkey(_screenshotHotkey);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                CaptureScreenshot();
            }
            base.WndProc(ref m);
        }

        private void CaptureScreenshot()
        {
            var bmp = ScreenshotHelper.CaptureRegion();
            if (bmp != null)
            {
                Clipboard.SetImage(bmp);
                _history.Add(new ClipboardItem(null, bmp, DateTime.Now));
            }
        }

        private void ShowPage(Control page)
        {
            _historyPage.Visible = false;
            _keybindsPage.Visible = false;
            page.Visible = true;
        }

        private void OnKeybindChanged(string action, Keys newKey)
        {
            if (action == "Region Screenshot")
            {
                _screenshotHotkey = newKey;
                _hotkeyManager?.RegisterHotkey(_screenshotHotkey);
            }
        }
    }
} 