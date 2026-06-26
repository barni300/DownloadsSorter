using System;
using System.IO;
using System.Collections.Generic;

string sourceDir = @"Your path to the Downloads or any other folder";


if (!Directory.Exists(sourceDir))
{
    Console.WriteLine($"Error: Folder {sourceDir} not found.");
    return;
}

var sortingRules = new Dictionary<string, string[]>
{
    { "Images🖼️",    new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".bmp" } },
    { "Documents📑", new[] { ".pdf", ".docx", ".doc", ".xlsx", ".txt", ".pptx" } },
    { "Archives🗄️",  new[] { ".zip", ".rar", ".7z", ".tar", ".gz" } },
    { "Programs💽",  new[] { ".exe", ".msi"} },
    { "Videos🎞️",    new[] { ".mp4", ".mkv", ".avi", ".mov" } },
    { "Music🎵",     new[] { ".mp3", ".wav", ".flac", ".aac" } }
};

Console.WriteLine($"Start sorting the folder: {sourceDir}\n");

try
{
    string[] files = Directory.GetFiles(sourceDir);
    int movedCount = 0;

    foreach (string file in files)
    {
        string extension = Path.GetExtension(file).ToLower();
        string fileName = Path.GetFileName(file);
        
        bool isSorted = false;
        
        foreach (var rule in sortingRules)
        {
            string targetFolderName = rule.Key;
            string[] allowedExtensions = rule.Value;

            if (ContainsExtension(allowedExtensions, extension))
            {
                MoveFile(sourceDir, file, targetFolderName, fileName, extension);
                movedCount++;
                isSorted = true;
                break;
            }
        }

        
        if (!isSorted)
        {
            MoveFile(sourceDir, file, "Unsorted⁉️", fileName, extension);
            movedCount++;
        }
    }

    Console.WriteLine($"\nSorting complete! Total files processed: {movedCount}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

static void MoveFile(string sourceDir, string currentFilePath, string targetFolderName, string fileName, string extension)
{
    string targetDir = Path.Combine(sourceDir, targetFolderName);
    
    if (!Directory.Exists(targetDir))
    {
        Directory.CreateDirectory(targetDir);
    }

    string destFile = Path.Combine(targetDir, fileName);

    if (File.Exists(destFile))
    {
        string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        destFile = Path.Combine(targetDir, $"{nameWithoutExt}_{timestamp}{extension}");
    }

    File.Move(currentFilePath, destFile);
    Console.WriteLine($"[OK] Moved: {fileName} -> {targetFolderName}/");
}

static bool ContainsExtension(string[] extensions, string ext)
{
    foreach (var e in extensions)
    {
        if (e == ext) return true;
    }
    return false;
}