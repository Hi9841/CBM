using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ClipboardManager
{
    public static class ScreenshotHelper
    {
        public static Bitmap CaptureRegion()
        {
            using (var overlay = new RegionSelectorForm())
            {
                if (overlay.ShowDialog() == DialogResult.OK)
                {
                    var rect = overlay.SelectedRegion;
                    if (rect.Width > 0 && rect.Height > 0)
                    {
                        var bmp = new Bitmap(rect.Width, rect.Height);
                        using (var g = Graphics.FromImage(bmp))
                        {
                            g.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
                        }
                        return bmp;
                    }
                }
            }
            return null;
        }
    }

    public class RegionSelectorForm : Form
    {
        public Rectangle SelectedRegion { get; private set; }
        private Point _start;
        private Point _end;
        private bool _dragging = false;

        public RegionSelectorForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.3;
            this.BackColor = Color.Black;
            this.TopMost = true;
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Cross;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _dragging = true;
            _start = e.Location;
            _end = e.Location;
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_dragging)
            {
                _end = e.Location;
                Invalidate();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _dragging = false;
            SelectedRegion = GetRectangle(_start, _end);
            DialogResult = DialogResult.OK;
            Close();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_dragging)
            {
                var rect = GetRectangle(_start, _end);
                using (var pen = new Pen(Color.Red, 2))
                using (var brush = new SolidBrush(Color.FromArgb(80, Color.White)))
                {
                    e.Graphics.FillRectangle(brush, rect);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }
    }
} 