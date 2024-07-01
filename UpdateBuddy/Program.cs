using System.Configuration;

namespace UpdateBuddy;

internal static class Program
{
    public static bool ShowTipButton = true;
    
    private static List<Mod> modsToUpdate;
    
    [STAThread]
    private static async Task Main()
    {
        if (!await HasInternetConnection()) return;
        ApplicationConfiguration.Initialize();
        
        string? showTipButton = ConfigurationManager.AppSettings["ShowTipButton"];
        ShowTipButton = string.IsNullOrEmpty(showTipButton) || bool.Parse(showTipButton);
        
        modsToUpdate = new();
        UpdateChecker updateChecker = new(ref modsToUpdate);
        await updateChecker.RunUpdateChecks();
    }

    private static async Task<bool> HasInternetConnection()
    {
        try
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync("http://clients3.google.com/generate_204");
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while checking for internet connection: {e.Message}");
            return false;
        }
    }
}