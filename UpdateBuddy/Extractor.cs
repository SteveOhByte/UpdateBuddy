using System.IO.Compression;

namespace UpdateBuddy;

public static class Extractor
{
    /// <summary>
    /// Extracts the contents of a zip file to a specified directory.
    /// </summary>
    /// <param name="zipPath">The path to the zip file.</param>
    /// <param name="extractTo">The directory to extract the contents to.</param>
    /// <param name="modName">The name of the mod being extracted.</param>
    /// <param name="progress">The progress reporter to track the extraction progress.</param>
    /// <returns>A Task representing the asynchronous extraction operation.</returns>
    public static async Task ExtractAsync(string zipPath, string extractTo, string modName, IProgress<int> progress)
    {
        await Task.Run(() =>
        {
            try
            {
                if (!Directory.Exists(extractTo))
                    Directory.CreateDirectory(extractTo);

                using ZipArchive archive = ZipFile.OpenRead(zipPath);
                int totalFiles = archive.Entries.Count;
                for (int i = 0; i < totalFiles; i++)
                {
                    ZipArchiveEntry entry = archive.Entries[i];
                    string destinationPath = Path.GetFullPath(Path.Combine(extractTo, entry.FullName));

                    if (!destinationPath.StartsWith(Path.GetFullPath(extractTo), StringComparison.OrdinalIgnoreCase))
                        continue;

                    string? destinationDir = Path.GetDirectoryName(destinationPath);
                    if (!string.IsNullOrEmpty(destinationDir) && !Directory.Exists(destinationDir))
                        Directory.CreateDirectory(destinationDir);

                    if (destinationPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                        continue;

                    try
                    {
                        if (File.Exists(destinationPath))
                        {
                            File.SetAttributes(destinationPath, FileAttributes.Normal);
                            File.Delete(destinationPath);
                        }

                        entry.ExtractToFile(destinationPath, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to extract {entry.FullName} to {destinationPath}: {ex.Message}");
                    }

                    progress?.Report((i + 1) * 100 / totalFiles);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error extracting {modName}: {e.Message}", "Update Buddy - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        });
    }
}