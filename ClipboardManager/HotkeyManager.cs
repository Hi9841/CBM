using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ClipboardManager
{
    public class HotkeyManager : IDisposable
    {
        private readonly IntPtr _windowHandle;
        private int _hotkeyId = 0;
        public event EventHandler HotkeyPressed = delegate { };
        public HotkeyManager(IntPtr windowHandle)
        {
            _windowHandle = windowHandle;
        }
        public void RegisterHotkey(Keys key)
        {
            UnregisterHotkey();
            _hotkeyId = key.GetHashCode();
            int modifiers = 0;
            if (key.HasFlag(Keys.Control)) modifiers |= MOD_CONTROL;
            if (key.HasFlag(Keys.Shift)) modifiers |= MOD_SHIFT;
            if (key.HasFlag(Keys.Alt)) modifiers |= MOD_ALT;
            var mainKey = (int)(key & ~Keys.Control & ~Keys.Shift & ~Keys.Alt);
            RegisterHotKey(_windowHandle, _hotkeyId, modifiers, mainKey);
        }
        public void UnregisterHotkey()
        {
            if (_hotkeyId != 0)
                UnregisterHotKey(_windowHandle, _hotkeyId);
        }
        public void Dispose() => UnregisterHotkey();

        private const int MOD_CONTROL = 0x2;
        private const int MOD_SHIFT = 0x4;
        private const int MOD_ALT = 0x1;
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
} 