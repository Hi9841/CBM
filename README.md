
# 📋 ClipboardManager (CBM)

A sleek, dark-themed clipboard history manager built with C# and WinForms.  
ClipboardManager automatically tracks and stores your clipboard content — including text and images — with timestamps for better productivity and reference.

---

## 🛠 Requirements

- ✅ [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- ✅ Windows 10/11 (x64)

---

## ✨ Features

- 🕒 **Clipboard History** – Instantly view all previously copied text and images.
- 🖼️ **Image Preview** – Supports displaying thumbnail previews of copied images.
- 📆 **Timestamp Tracking** – See when each item was copied.
- 🧼 **Clear All** – Wipe the entire clipboard history with one click.
- 🎯 **Keybind Support** – Quickly open the app or perform actions using custom hotkeys.
- ❌ **Delete Selected** – Remove specific clipboard entries easily.
- 💡 **Minimal UI** – Lightweight design focused on speed and usability.

---

## 📸 Screenshot

![image](https://github.com/user-attachments/assets/26cbc8de-39df-4fd4-a487-b457f74d2a74)  
<sup>Dark UI with text + image support, built for speed and simplicity.</sup>

---

## 🧭 Navigation

- `History` – View full clipboard history.
- `Keybinds` – Configure hotkeys

---

## 🚀 Getting Started

1. Clone the repo:
   ```bash
   git clone https://github.com/Hi9841/Hi9841.git
   cd Hi9841/CBM
   Open the CBM project in Visual Studio or your preferred C# editor

2. Build The App
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true - 
   p:IncludeAllContentForSelfExtract=true -p:TrimUnusedDependencies=false -o publish
   
This will output a portable .exe in the /publish folder.

