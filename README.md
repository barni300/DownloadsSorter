# Downloads Sorter

A fast C# (.NET) CLI utility created to automatically organize your cluttered downloads folder. The application scans a directory and sorts files into subfolders based on their extensions.

## Features

- **Automated Sorting:** Instantly categorizes files into specific groups (Images, Documents, Archives, Programs, Videos, Music).
- **"Unsorted" Folder Safety Net:** Any unrecognized or rare file types are automatically moved to an `Unsorted` folder, keeping the root directory perfectly clean.
- **Overwrite Protection:** If a file with the same name already exists in the destination folder, the tool automatically appends a unique timestamp to prevent data loss.

## Setup & Running

1. Clone the repository:
   ```bash
   git clone https://github.com
   ```
2. Open the project in your IDE.
3. In `Program.cs`, replace the placeholder with your actual folder path:
   ```csharp
   string sourceDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "C:\\Your\\Folder\\Path");
   ```
4. Run the application.

## Roadmap

- [ ] Add real-time background monitoring using `FileSystemWatcher`.
- [ ] Move extension rules configuration to an external `JSON` config file.
- [ ] Transition the utility into a background `Windows Service` / `Worker Service`.
