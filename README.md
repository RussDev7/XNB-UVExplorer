# XNB UV Explorer 🖼️

A lightweight WinForms tool for **inspecting & slicing XNB texture sheets**.  
(ideal for Terraria modding or any XNA/MonoGame asset work).

<p align="center">
  <img src="https://github.com/user-attachments/assets/5130c74c-4143-4e2d-9a48-2e019e1fb364" width="900" alt="Main window screenshot">
</p>

---

## ✨ Features
| Category | What it does |
|----------|--------------|
| **Tile detection** | Auto-scans a texture, finds 18 × 18 tiles (configurable), draws red rectangles, lists UVs in a grid |
| **Grid mode** | Uniform grid overlay with user-defined offsets `<U, V>` |
| **Dynamic mode** | Per-column seam detection, split-sprite handling, row/column sort toggle |
| **Data export** | One-click “Copy Grid” → clipboard (tab-delimited, header included) |
| **Zoom & pan** | 10 % – 500 % zoom, scroll-wheel + scrollbars |
| **Quality of life** | Live tile count, toastr-style alerts, embed-DLL resolver for single-file deployment |

---

## 🛠️ Prerequisites
* **Windows** (x86 / x64)
* **XNA Framework Redistributable 4.0**
* **.NET Framework 4.8** or newer  
  *(for build-from-source: Visual Studio 2019+ / `dotnet msbuild`)*

---

## 🚀 Getting started

```bash
git clone https://github.com/RussDev7/XNB-UVExplorer.git
cd XNBUVExplorer
XNBUVExplorer.exe           # If you downloaded a release zip
# or
msbuild XNBUVExplorer.sln   # Build from source → bin\Release\XNBUVExplorer.exe
