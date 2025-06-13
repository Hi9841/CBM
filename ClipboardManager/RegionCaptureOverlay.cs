using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ClipboardManager
{
    public class RegionCaptureOverlay : Form
    {
        public Rectangle SelectedRegion { get; private set; }
        private Point _start;
        private Point _end;
        private bool _dragging = false;
        private bool _canceled = false;
        private List<Form> _overlays = new List<Form>();
        public Bitmap? CaptureRegion()
        {
            _canceled = false;
            _overlays.Clear();
            foreach (var screen in Screen.AllScreens)
            {
                var overlay = new OverlayForm(screen.Bounds, this);
                overlay.Show();
                _overlays.Add(overlay);
            }
            Application.Run(this);
            foreach (var overlay in _overlays) overlay.Close();
            if (_canceled || SelectedRegion.Width == 0 || SelectedRegion.Height == 0)
                return null;
            var bmp = new Bitmap(SelectedRegion.Width, SelectedRegion.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(SelectedRegion.Location, Point.Empty, SelectedRegion.Size);
            }
            return bmp;
        }
        public RegionCaptureOverlay()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.01;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.DoubleBuffered = true;
            this.KeyPreview = true;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _canceled = true;
                this.Close();
            }
            base.OnKeyDown(e);
        }
        public void StartDrag(Point start)
        {
            _dragging = true;
            _start = start;
            _end = start;
            Invalidate();
        }
        public void UpdateDrag(Point end)
        {
            if (_dragging)
            {
                _end = end;
                Invalidate();
            }
        }
        public void EndDrag(Point end)
        {
            _dragging = false;
            _end = end;
            SelectedRegion = GetRectangle(_start, _end);
            this.Close();
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
        private class OverlayForm : Form
        {
            private RegionCaptureOverlay _parent;
            public OverlayForm(Rectangle bounds, RegionCaptureOverlay parent)
            {
                _parent = parent;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = bounds;
                this.Opacity = 0.3;
                this.BackColor = Color.Black;
                this.TopMost = true;
                this.DoubleBuffered = true;
                this.Cursor = Cursors.Cross;
                this.ShowInTaskbar = false;
                this.KeyPreview = true;
            }
            protected override void OnMouseDown(MouseEventArgs e)
            {
                _parent.StartDrag(PointToScreen(e.Location));
            }
            protected override void OnMouseMove(MouseEventArgs e)
            {
                _parent.UpdateDrag(PointToScreen(e.Location));
            }
            protected override void OnMouseUp(MouseEventArgs e)
            {
                _parent.EndDrag(PointToScreen(e.Location));
            }
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    _parent._canceled = true;
                    _parent.Close();
                }
                base.OnKeyDown(e);
            }
        }
    }
} 