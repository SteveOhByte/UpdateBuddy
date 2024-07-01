using System.Reflection;
using Mono.Cecil;

namespace UpdateBuddy;

public class UpdateChecker
{
    private List<Mod> modsToUpdate;

    public UpdateChecker(ref List<Mod> modsToUpdate)
    {
        this.modsToUpdate = modsToUpdate;
    }
    
    public async Task RunUpdateChecks()
    {
        await InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        // Initialize directories, process DLLs, and check for updates
        await ProcessDllsAsync();
        
        if (modsToUpdate.Count > 0)
            Application.Run(new MainForm(modsToUpdate));
    }

    private async Task ProcessDllsAsync()
    {
        string gta5Dir = Application.StartupPath;
        string pluginsDir = Path.Combine(gta5Dir, "plugins");
        string lspdfrDir = Path.Combine(pluginsDir, "LSPDFR");

        // Verify existence
        if (!File.Exists(Path.Combine(gta5Dir, "GTA5.exe")))
        {
            MessageBox.Show("GTA5.exe not found. Exiting...", "Update Buddy - Critical Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            Environment.Exit(1);
        }

        if (!Directory.Exists(pluginsDir))
        {
            MessageBox.Show("Plugins directory not found. Exiting...", "Update Buddy - Critical Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }

        if (!Directory.Exists(lspdfrDir))
        {
            MessageBox.Show("LSPDFR directory not found. Exiting...", "Update Buddy - Critical Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }

        List<string> dllFiles = new();
        dllFiles.AddRange(Directory.GetFiles(gta5Dir, "*.dll"));
        dllFiles.AddRange(Directory.GetFiles(pluginsDir, "*.dll"));
        dllFiles.AddRange(Directory.GetFiles(lspdfrDir, "*.dll"));

        foreach (string dllFile in dllFiles)
            await ProcessDllAsync(dllFile);
    }

    private async Task ProcessDllAsync(string dllFilePath)
    {
        try
        {
            using AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(dllFilePath);
            string modName = string.Empty;
            string updateUrl = string.Empty;
            string versionUrl = string.Empty;
            string currentVersion = string.Empty;

            foreach (CustomAttribute attribute in assembly.CustomAttributes)
            {
                if (attribute.AttributeType.FullName != typeof(AssemblyMetadataAttribute).FullName) continue;
                
                if (attribute.ConstructorArguments.Count >= 2)
                {
                    string key = (string)attribute.ConstructorArguments[0].Value;
                    string value = (string)attribute.ConstructorArguments[1].Value;

                    switch (key)
                    {
                        case "UpdateBuddy-ModName":
                            modName = value;
                            break;
                        case "UpdateBuddy-UpdateUrl":
                            updateUrl = value;
                            break;
                        case "UpdateBuddy-VersionUrl":
                            versionUrl = value;
                            break;
                        case "UpdateBuddy-Version":
                            currentVersion = value;
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(modName) && !string.IsNullOrEmpty(updateUrl) && !string.IsNullOrEmpty(versionUrl) && !string.IsNullOrEmpty(currentVersion))
            {
                (bool updateAvailable, string newVersion) = await CheckForUpdatesAsync(modName, versionUrl, currentVersion);
                
                if (updateAvailable)
                    modsToUpdate.Add(new(modName, currentVersion, newVersion, updateUrl));
            }
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("Invalid IL format"))
        {
            // Ignore the exception for DLLs that are not UpdateBuddy DLLs
        }
        catch (BadImageFormatException)
        {
            // Ignore the exception for DLLs that are not valid .NET assemblies
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to process {dllFilePath}: {ex.Message}", "Update Buddy - Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task<(bool updateAvailable, string newVersion)> CheckForUpdatesAsync(string modName, string versionUrl, string currentVersion)
    {
        string tempFile = Path.Combine(Path.GetTempPath(), "UpdateBuddyVersion.txt");
        await Downloader.DownloadAsync(versionUrl, tempFile, modName, null);

        string newVersion = await File.ReadAllTextAsync(tempFile);
        bool updateAvailable = new Version(newVersion).CompareTo(new(currentVersion)) > 0;
        
        return (updateAvailable, newVersion);
    }
}