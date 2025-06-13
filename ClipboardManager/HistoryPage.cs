using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClipboardManager
{
    public partial class HistoryPage : UserControl
    {
        private readonly ClipboardHistory _history;
        private readonly ImageList _imageList = new ImageList();
        private Timer _clipboardTimer;
        private string? _lastClipboardText;
        private Image? _lastClipboardImage;
        
        // Constructor that accepts a shared ClipboardHistory instance
        public HistoryPage(ClipboardHistory history)
        {
            _history = history;
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
            _imageList.ImageSize = new Size(80, 80);
            lvHistory.SmallImageList = _imageList;
            lvHistory.OwnerDraw = false;
            lvHistory.View = View.Details;
            if (lvHistory.Columns.Count > 0)
                lvHistory.Columns[0].Width = 120;
            _history.HistoryChanged += (s, e) => UpdateListView();
            txtSearch.TextChanged += (s, e) => UpdateListView();
            btnClearAll.Click += (s, e) => { _history.Clear(); };
            btnDeleteSelected.Click += (s, e) => DeleteSelectedItem();
            btnCopy.Click += (s, e) => CopySelectedToClipboard(showMessage: true);
            lvHistory.DoubleClick += (s, e) => CopySelectedToClipboard();
            lvHistory.MouseUp += LvHistory_MouseUp;
            this.Resize += (s, e) => AutoResizeColumns();
            lvHistory.Resize += (s, e) => AutoResizeColumns();
            var cleanupTimer = new Timer { Interval = 60 * 1000 };
            cleanupTimer.Tick += (s, e) => _history.RemoveOlderThan(TimeSpan.FromHours(3));
            cleanupTimer.Start();
            // Clipboard monitoring
            _clipboardTimer = new Timer { Interval = 400 };
            _clipboardTimer.Tick += ClipboardTimer_Tick;
            _clipboardTimer.Start();
        }
        private void UpdateListView()
        {
            lvHistory.BeginUpdate();
            lvHistory.Items.Clear();
            _imageList.Images.Clear();
            var items = _history.Search(txtSearch.Text).ToList();
            int idx = 0;
            foreach (var item in items)
            {
                ListViewItem lvi;
                if (item.IsImage && item.Image != null)
                {
                    var thumb = new Bitmap(item.Image, new Size(80, 80));
                    _imageList.Images.Add(idx.ToString(), thumb);
                    lvi = new ListViewItem("", idx);
                    lvi.SubItems.Add("[Image]");
                }
                else
                {
                    lvi = new ListViewItem("");
                    lvi.SubItems.Add(Truncate(item.Text, 80));
                }
                lvi.SubItems.Add(item.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi.Tag = item;
                lvHistory.Items.Add(lvi);
                idx++;
            }
            lvHistory.EndUpdate();
        }
        private void CopySelectedToClipboard(bool showMessage = false)
        {
            if (lvHistory.SelectedItems.Count == 1)
            {
                var item = lvHistory.SelectedItems[0].Tag as ClipboardItem;
                if (item != null)
                {
                    if (item.IsText)
                        Clipboard.SetText(item.Text);
                    else if (item.IsImage)
                        Clipboard.SetImage(item.Image);
                    if (showMessage)
                        MessageBox.Show("Copied to clipboard.", "Clipboard Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void DeleteSelectedItem()
        {
            if (lvHistory.SelectedItems.Count == 1)
            {
                var item = lvHistory.SelectedItems[0].Tag as ClipboardItem;
                if (item != null)
                    _history.Remove(item);
            }
        }
        private void LvHistory_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lvHistory.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    var menu = new ContextMenuStrip();
                    var copyItem = new ToolStripMenuItem("Copy to Clipboard");
                    var deleteItem = new ToolStripMenuItem("Delete");
                    copyItem.Click += (s, ev) => CopySelectedToClipboard();
                    deleteItem.Click += (s, ev) => DeleteSelectedItem();
                    menu.Items.AddRange(new ToolStripItem[] { copyItem, deleteItem });
                    ThemeHelper.ApplyTheme(menu);
                    menu.Show(lvHistory, e.Location);
                }
            }
        }
        private string Truncate(string? text, int max)
        {
            if (string.IsNullOrEmpty(text)) return text ?? string.Empty;
            return text.Length > max ? text.Substring(0, max) + "..." : text;
        }
        private void ClipboardTimer_Tick(object? sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    var img = Clipboard.GetImage();
                    if (img != null && (_lastClipboardImage == null || !ImagesAreEqual(_lastClipboardImage, img)))
                    {
                        _lastClipboardImage = new Bitmap(img);
                        // Always add the image - let ClipboardHistory handle deduplication
                        _history.Add(new ClipboardItem(null, _lastClipboardImage, DateTime.Now));
                    }
                }
                else if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    if (!string.IsNullOrWhiteSpace(text) && text != _lastClipboardText)
                    {
                        _lastClipboardText = text;
                        _history.Add(new ClipboardItem(text, null, DateTime.Now));
                    }
                }
            }
            catch { /* Clipboard busy, ignore */ }
        }
        private bool ImagesAreEqual(Image? img1, Image? img2)
        {
            if (img1 == null || img2 == null) return false;
            if (img1.Size != img2.Size) return false;
            using (var ms1 = new System.IO.MemoryStream())
            using (var ms2 = new System.IO.MemoryStream())
            {
                img1.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
                img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                return ms1.ToArray().SequenceEqual(ms2.ToArray());
            }
        }
        private void AutoResizeColumns()
        {
            int totalWidth = lvHistory.ClientSize.Width;
            if (totalWidth <= 0 || lvHistory.Columns.Count < 3) return;
            int imageColWidth = 120;
            int timestampColWidth = 120;
            int snippetColWidth = totalWidth - imageColWidth - timestampColWidth - 4; // 4 for borders
            if (snippetColWidth < 80) snippetColWidth = 80;
            lvHistory.Columns[0].Width = imageColWidth;
            lvHistory.Columns[1].Width = snippetColWidth;
            lvHistory.Columns[2].Width = timestampColWidth;
        }
    }
} 