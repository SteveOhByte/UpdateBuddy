using System.Diagnostics;
using System.IO;
using Rage;
using Rage.Attributes;

[assembly: Plugin("UpdateBuddyLauncher", Description = "Launches UpdateBuddy upon RPH load", Author = "SteveOhByte")]
namespace UpdateBuddyLauncher
{
    public static class EntryPoint
    {
        public static void Main()
        {
            // Get current working directory
            string directory = Directory.GetCurrentDirectory();

            // Fetch the path of UpdateBuddy.exe
            string updateBuddyPath = Path.Combine(directory, "UpdateBuddy.exe");
            updateBuddyPath = Path.GetFullPath(updateBuddyPath); // Resolve the full path

            Game.LogTrivial($"Attempting to launch UpdateBuddy at {updateBuddyPath}");
            // Check if it exists
            if (!File.Exists(updateBuddyPath))
            {
                Game.LogTrivial($"UpdateBuddy.exe not found at {updateBuddyPath}");
                return;
            }

            // Launch UpdateBuddy
            try
            {
                Process.Start(updateBuddyPath);
            }
            catch
            {
                Game.LogTrivial($"Failed to launch UpdateBuddy at {updateBuddyPath}");
            }
        }
    }
}