namespace UpdateBuddy;

public class Mod
{
    public string Name { get; }
    public string CurrentVersion { get; }
    public string LatestVersion { get; }
    public string UpdateUrl { get; }

    public Mod(string name, string currentVersion, string latestVersion, string updateUrl)
    {
        Name = name;
        CurrentVersion = currentVersion;
        LatestVersion = latestVersion;
        UpdateUrl = updateUrl;
    }
}