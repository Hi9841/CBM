using System;
using System.Collections.Generic;
using System.Linq;

namespace ClipboardManager
{
    public class ClipboardHistory
    {
        private readonly List<ClipboardItem> _items = new();
        private readonly object _lock = new();
        public event EventHandler HistoryChanged = delegate { };

        public IReadOnlyList<ClipboardItem> Items
        {
            get { lock (_lock) { return _items.ToList(); } }
        }

        public void Add(ClipboardItem item)
        {
            lock (_lock)
            {
                if (_items.Contains(item))
                    return; // Deduplicate
                _items.Insert(0, item); // Most recent at top
                HistoryChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Remove(ClipboardItem item)
        {
            lock (_lock)
            {
                _items.Remove(item);
                HistoryChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Clear()
        {
            lock (_lock)
            {
                _items.Clear();
                HistoryChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public IEnumerable<ClipboardItem> Search(string query)
        {
            lock (_lock)
            {
                if (string.IsNullOrWhiteSpace(query))
                    return _items.ToList();
                return _items.Where(i => i.IsText && i.Text.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
        }

        public void RemoveOlderThan(TimeSpan maxAge)
        {
            lock (_lock)
            {
                var cutoff = DateTime.Now - maxAge;
                _items.RemoveAll(i => i.Timestamp < cutoff);
                HistoryChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
} 