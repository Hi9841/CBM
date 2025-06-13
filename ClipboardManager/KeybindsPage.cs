using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClipboardManager
{
    public partial class KeybindsPage : UserControl
    {
        private Dictionary<string, Keys> _keybinds = new();
        public event Action<string, Keys>? KeybindChanged;
        public KeybindsPage()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            keybindsPanel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            keybindsPanel.ForeColor = System.Drawing.Color.Gainsboro;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
                ctrl.ForeColor = System.Drawing.Color.Gainsboro;
            }
            keybindsPanel.VerticalScroll.Visible = true;
            keybindsPanel.Scroll += (s, e) => ThemeHelper.ApplyDarkScrollBar(keybindsPanel);
            _keybinds["Region Screenshot"] = Keys.Control | Keys.P;
            UpdateKeybindList();
            var btnDeleteAll = new Button { Text = "Delete All", Width = 120, Height = 32, BackColor = System.Drawing.Color.FromArgb(32,32,32), ForeColor = System.Drawing.Color.Gainsboro, FlatStyle = FlatStyle.Flat, Anchor = AnchorStyles.Bottom | AnchorStyles.Left, Location = new System.Drawing.Point(10, this.Height - 50) };
            var btnDeleteSelected = new Button { Text = "Delete Selected", Width = 140, Height = 32, BackColor = System.Drawing.Color.FromArgb(32,32,32), ForeColor = System.Drawing.Color.Gainsboro, FlatStyle = FlatStyle.Flat, Anchor = AnchorStyles.Bottom | AnchorStyles.Left, Location = new System.Drawing.Point(140, this.Height - 50) };
            this.Controls.Add(btnDeleteAll);
            this.Controls.Add(btnDeleteSelected);
        }
        private void UpdateKeybindList()
        {
            keybindsPanel.Controls.Clear();
            int y = 10;
            foreach (var kvp in _keybinds)
            {
                var lbl = new Label { Text = kvp.Key, ForeColor = System.Drawing.Color.Gainsboro, BackColor = System.Drawing.Color.FromArgb(24, 24, 24), Location = new System.Drawing.Point(10, y), Width = 180 };
                var txt = new TextBox { Text = KeyToString(kvp.Value), ReadOnly = true, Location = new System.Drawing.Point(200, y), Width = 120, BackColor = System.Drawing.Color.FromArgb(32,32,32), ForeColor = System.Drawing.Color.Gainsboro, BorderStyle = BorderStyle.FixedSingle };
                var btn = new Button { Text = "Set", Location = new System.Drawing.Point(340, y-2), Width = 60, BackColor = System.Drawing.Color.FromArgb(32,32,32), ForeColor = System.Drawing.Color.Gainsboro, FlatStyle = FlatStyle.Flat };
                btn.Click += (s, e) => SetKeybind(kvp.Key, txt);
                keybindsPanel.Controls.Add(lbl);
                keybindsPanel.Controls.Add(txt);
                keybindsPanel.Controls.Add(btn);
                y += 40;
            }
        }
        private void SetKeybind(string action, TextBox txt)
        {
            using (var dlg = new KeybindCaptureDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    var newKey = dlg.SelectedKey;
                    if (_keybinds.ContainsValue(newKey))
                    {
                        MessageBox.Show("This keybind is already assigned.", "Duplicate Keybind", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _keybinds[action] = newKey;
                    txt.Text = KeyToString(newKey);
                    KeybindChanged?.Invoke(action, newKey);
                }
            }
        }
        private string KeyToString(Keys key)
        {
            var parts = new List<string>();
            if (key.HasFlag(Keys.Control)) parts.Add("Ctrl");
            if (key.HasFlag(Keys.Shift)) parts.Add("Shift");
            if (key.HasFlag(Keys.Alt)) parts.Add("Alt");
            var mainKey = key & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;
            if (mainKey != Keys.None) parts.Add(mainKey.ToString());
            return string.Join("+", parts);
        }
    }

    public partial class KeybindCaptureDialog : Form
    {
        public Keys SelectedKey { get; private set; }
        private TextBox txtHotkey;
        private Keys _currentKeys = Keys.None;
        public KeybindCaptureDialog()
        {
            this.Text = "Set Keybind";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(260, 80);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            var lbl = new Label { Text = "Press new key combination:", ForeColor = System.Drawing.Color.WhiteSmoke, Location = new System.Drawing.Point(10, 10), Width = 240 };
            txtHotkey = new TextBox { Location = new System.Drawing.Point(10, 40), Width = 240, ReadOnly = true, BackColor = System.Drawing.Color.FromArgb(32,32,32), ForeColor = System.Drawing.Color.WhiteSmoke };
            txtHotkey.KeyDown += TxtHotkey_KeyDown;
            txtHotkey.KeyUp += TxtHotkey_KeyUp;
            this.Controls.Add(lbl);
            this.Controls.Add(txtHotkey);
            txtHotkey.Focus();
        }
        private void TxtHotkey_KeyDown(object? sender, KeyEventArgs e)
        {
            _currentKeys = e.KeyData;
            txtHotkey.Text = KeyToString(_currentKeys);
            e.SuppressKeyPress = true;
        }
        private void TxtHotkey_KeyUp(object? sender, KeyEventArgs e)
        {
            SelectedKey = _currentKeys;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private string KeyToString(Keys key)
        {
            var parts = new List<string>();
            if (key.HasFlag(Keys.Control)) parts.Add("Ctrl");
            if (key.HasFlag(Keys.Shift)) parts.Add("Shift");
            if (key.HasFlag(Keys.Alt)) parts.Add("Alt");
            var mainKey = key & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;
            if (mainKey != Keys.None) parts.Add(mainKey.ToString());
            return string.Join("+", parts);
        }
    }
} 