# Clipboard Manager

A clean, modern Windows Forms clipboard manager with region screenshot capture functionality, built for .NET 6+ with a fully black-themed UI.

## Features

### 📋 Clipboard History
- **Text & Image Support**: Automatically tracks both text and image clipboard entries
- **Smart Deduplication**: Images appear only once, even if copied multiple times
- **Flat Black Cards**: Clean, modern UI with text entries in dark cards
- **Image Thumbnails**: Visual previews for image entries
- **One-Click Copy**: Easily copy any item back to clipboard
- **Manual Save**: Select images and save as PNG files

### 🖼️ Region Screenshot Capture
- **Global Hotkey**: Default `Ctrl + Shift + P` (customizable)
- **Drag-to-Select**: Fullscreen overlay with visual selection
- **Advanced Capture**: Uses BitBlt with CaptureBlt to capture:
  - Right-click context menus
  - Fullscreen games and videos
  - Taskbar overlays
  - Layered windows
- **Clipboard Integration**: Screenshots automatically copied to clipboard and appear in history

### 🎛️ Keybind Configuration
- **Custom Hotkeys**: Set any key combination for region capture
- **Multi-Key Support**: Ctrl, Shift, Alt combinations
- **Real-Time Capture**: Press keys in textbox to set hotkey
- **Test & Reset**: Verify hotkey registration and reset to defaults
- **Startup Control**: Enable/disable Windows startup with checkbox

### 🎨 Black Theme
- **Pure Black Background**: #000000 to #111111
- **Grayscale Text**: #888888 and #CCCCCC only
- **Flat Design**: No gradients, shadows, or color accents
- **Modern UI**: Clean, professional appearance

### 🔧 System Tray Integration
- **Minimize to Tray**: App stays running in system tray when closed
- **Tray Context Menu**: Show/Hide/Exit options via right-click
- **Double-Click**: Double-click tray icon to show window
- **Windows Startup**: Optional startup with Windows (starts minimized)

## Usage

### Basic Operation
1. **Launch the app** - Clipboard monitoring starts automatically
2. **Copy text or images** - Items appear in the Clipboard History tab
3. **Click "Copy"** on text entries to copy back to clipboard
4. **Select images** using checkboxes and click "Save Selected" to save as PNG

### Region Screenshot
1. **Press hotkey** (default: `Ctrl + Shift + P`) from anywhere
2. **Drag to select** the region you want to capture
3. **Release mouse** to capture - image is copied to clipboard
4. **View in history** - captured image appears in the Clipboard History tab

### Customizing Hotkeys
1. **Go to Keybinds tab**
2. **Click in the text box** and press your desired key combination
3. **Click "Set Hotkey"** to apply
4. **Use "Test"** to verify the hotkey works
5. **Use "Reset"** to restore default hotkey

### System Tray Usage
- **Closing Window**: Click X to minimize to tray (app keeps running)
- **Show from Tray**: Double-click tray icon or right-click → Show
- **Exit Completely**: Right-click tray icon → Exit
- **Windows Startup**: Check "Start with Windows" in Keybinds tab

## Technical Details

- **Framework**: .NET 6+ Windows Forms
- **Capture Method**: BitBlt with CaptureBlt flag for layered window support
- **Image Deduplication**: SHA256 hash comparison
- **Memory Management**: Automatic cleanup and disposal
- **Hotkey System**: Win32 RegisterHotKey API
- **Multi-Monitor**: Full virtual screen support

## System Requirements

- Windows 10/11
- .NET 6.0 Runtime or later

## Building

```bash
dotnet build
dotnet run
```

## Command Line Options

- `--instant-capture`: Start region capture immediately without showing main window
- `--minimized`: Start minimized to system tray (used for Windows startup)

## Keyboard Shortcuts

- **Escape**: Cancel region selection
- **Right-click**: Cancel region selection
- **Default hotkey**: `Ctrl + Shift + P` (customizable)

---

*Clean, focused clipboard management with professional screenshot capabilities.* 
