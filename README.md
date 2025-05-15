# YTPMV Auto Video Generator 

## Overview

This workspace is for developing a C# Windows Forms application (using SharpDevelop 4.3) that:
- Loads audio using NAudio
- Analyzes audio (e.g., pitch/beat detection)
- Generates a YTPMV-style video script for Sony Vegas Pro 12
- Exports a `.cs` script compatible with Sony Vegas Pro 12 scripting engine

## Technologies

- **C# WinForms** (SharpDevelop 4.3)
- **Sony Vegas Pro 12 Scripting API** ([See official docs](https://www.vegascreativesoftware.info/us/forum/vegas-pro-12-scripting-documentation--92866/))
- **NAudio** ([See NAudio docs](https://github.com/naudio/NAudio))
- **.NET Framework 4.0/4.5**

## Project Structure

- `/YTPMVFormApp/` - Main WinForms app
- `/VegasScriptGenerator/` - Module for generating Vegas scripts
- `/AudioAnalyzer/` - Module for audio analysis (using NAudio)

## Quick Start

1. Open the solution in SharpDevelop 4.3.
2. Restore NuGet packages (NAudio).
3. Build and run the solution.
4. Use the UI to load audio, analyze, and export a Vegas script.

---
