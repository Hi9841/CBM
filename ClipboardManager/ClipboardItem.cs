using System;
using System.Drawing;

namespace ClipboardManager
{
    public class ClipboardItem
    {
        public string? Text { get; set; }
        public Image? Image { get; set; } // null if not an image item
        public DateTime Timestamp { get; set; }

        public bool IsText => !string.IsNullOrEmpty(Text);
        public bool IsImage => Image != null;

        public ClipboardItem(string? text, Image? image, DateTime timestamp)
        {
            Text = text;
            Image = image;
            Timestamp = timestamp;
        }

        // For deduplication: only text or image hash matters
        public override bool Equals(object? obj)
        {
            if (obj is ClipboardItem other)
            {
                if (IsText && other.IsText)
                    return string.Equals(Text, other.Text, StringComparison.Ordinal);
                if (IsImage && other.IsImage)
                    return Image?.GetHashCode() == other.Image?.GetHashCode();
            }
            return false;
        }

        public override int GetHashCode()
        {
            if (IsText) return Text!.GetHashCode();
            if (IsImage) return Image!.GetHashCode();
            return 0;
        }

        public override string ToString()
        {
            if (IsText && Text != null)
            {
                var snippet = Text.Length > 64 ? Text.Substring(0, 64) + "..." : Text;
                return $"{snippet} ({Timestamp:yyyy-MM-dd HH:mm:ss})";
            }
            if (IsImage)
            {
                return $"[Image] ({Timestamp:yyyy-MM-dd HH:mm:ss})";
            }
            return base.ToString();
        }

        public Image GetThumbnail(int size = 40)
        {
            if (Image == null) throw new InvalidOperationException();
            return new Bitmap(Image, new Size(size, size));
        }
    }
} 