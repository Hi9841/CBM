using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ClipboardManager
{
    public static class ThemeHelper
    {
        // Main theme colors
        public static readonly Color Background = Color.FromArgb(24, 24, 24);
        public static readonly Color Foreground = Color.FromArgb(245, 245, 245);
        public static readonly Color Accent = Color.FromArgb(60, 60, 60);
        public static readonly Color Selection = Color.FromArgb(36, 36, 36);
        public static readonly Color ButtonBackground = Color.FromArgb(32, 32, 32);
        public static readonly Color ButtonHover = Color.FromArgb(50, 50, 50);
        public static readonly Color Border = Color.FromArgb(80, 80, 80);
        public static readonly Color Placeholder = Color.FromArgb(130, 130, 130);
        public static readonly Color SidebarBackground = Color.FromArgb(24, 24, 24);
        public static readonly Color TextBoxBackground = Color.FromArgb(32, 32, 32);

        public static void ApplyTheme(Form form)
        {
            if (form == null) return;
            form.BackColor = Background;
            form.ForeColor = Foreground;
            foreach (Control c in form.Controls)
                ApplyTheme(c);
        }

        public static void ApplyTheme(Control control)
        {
            if (control == null) return;
            if (control is TextBox tb)
            {
                tb.BackColor = TextBoxBackground;
                tb.ForeColor = Foreground;
                tb.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is Button btn)
            {
                btn.BackColor = ButtonBackground;
                btn.ForeColor = Foreground;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Border;
                btn.FlatAppearance.BorderSize = 1;
            }
            else if (control is ListView lv)
            {
                lv.BackColor = Background;
                lv.ForeColor = Foreground;
                lv.BorderStyle = BorderStyle.None;
                lv.FullRowSelect = true;
                lv.OwnerDraw = true;
                lv.HideSelection = false;
                lv.View = View.Details;
                lv.DrawColumnHeader += (s, e) =>
                {
                    using (var b = new SolidBrush(ButtonBackground))
                        e.Graphics.FillRectangle(b, e.Bounds);
                    TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Foreground);
                };
                lv.DrawItem += (s, e) =>
                {
                    var bg = e.Item.Selected ? Selection : Background;
                    using (var b = new SolidBrush(bg))
                        e.Graphics.FillRectangle(b, e.Bounds);
                    e.DrawText(TextFormatFlags.Left);
                };
                lv.DrawSubItem += (s, e) =>
                {
                    var bg = e.Item.Selected ? Selection : Background;
                    using (var b = new SolidBrush(bg))
                        e.Graphics.FillRectangle(b, e.Bounds);
                    if (e.ColumnIndex == 0 && e.Item.ImageIndex >= 0 && lv.SmallImageList != null)
                    {
                        // Center the image vertically and horizontally
                        var img = lv.SmallImageList.Images[e.Item.ImageIndex];
                        int x = e.Bounds.Left + (e.Bounds.Width - img.Width) / 2;
                        int y = e.Bounds.Top + (e.Bounds.Height - img.Height) / 2;
                        e.Graphics.DrawImage(img, x, y, img.Width, img.Height);
                    }
                    else
                    {
                        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, Foreground);
                    }
                };
            }
            else if (control is ListBox lb)
            {
                lb.BackColor = Background;
                lb.ForeColor = Foreground;
                lb.BorderStyle = BorderStyle.None;
            }
            else if (control is ContextMenuStrip cms)
            {
                cms.BackColor = Background;
                cms.ForeColor = Foreground;
                foreach (ToolStripItem item in cms.Items)
                {
                    if (item == null) continue;
                    item.BackColor = Background;
                    item.ForeColor = Foreground;
                }
            }
            else
            {
                control.BackColor = Background;
                control.ForeColor = Foreground;
            }

            foreach (Control child in control.Controls)
                if (child != null) ApplyTheme(child);
        }

        public static void ApplyDarkScrollBar(Control control)
        {
            // Windows 10+ dark scrollbars
            const int SB_VERT = 1;
            const int WM_NCPAINT = 0x85;
            if (control is ScrollableControl sc)
            {
                var handle = sc.Handle;
                SetWindowTheme(handle, "DarkMode_Explorer", null);
                SendMessage(handle, WM_NCPAINT, (IntPtr)SB_VERT, IntPtr.Zero);
            }
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string? pszSubIdList);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
} 