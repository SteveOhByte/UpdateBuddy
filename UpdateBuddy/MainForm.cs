using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using MaterialSkin;
using MaterialSkin.Controls;
using Mono.Cecil;

namespace UpdateBuddy;

public partial class MainForm : MaterialForm
{
    private List<Mod> modsToUpdate;
    private int currentModIndex = 0;
    private int modsUpdated = 0;

    public MainForm(List<Mod> modsToUpdate)
    {
        this.modsToUpdate = modsToUpdate;
        InitializeComponent();

        if (Program.ShowTipButton)
        {
            tipButton.Visible = true;
            dismissTipButton.Visible = true;
        }

        MaterialSkinManager? materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new(
            Primary.Green800,   // Primary color (dark green)
            Primary.Green900,   // Darker shade of primary color
            Primary.Green500,   // Lighter shade of primary color
            Accent.LightGreen200, // Accent color
            TextShade.WHITE     // Text color
        );

        ShowNextUpdate();
    }

    private void ShowNextUpdate()
    {
        if (InvokeRequired)
        {
            Invoke((MethodInvoker)ShowNextUpdate);
            return;
        }

        if (currentModIndex < modsToUpdate.Count)
        {
            Mod mod = modsToUpdate[currentModIndex];
            lblTitle.Text = $"Update available for\n{mod.Name}.";
            lblCurrentVersion.Text = $"Current version: {mod.CurrentVersion}";
            lblNewVersion.Text = $"New version: {mod.LatestVersion}";
        }
        else
        {
            if (modsUpdated > 0)
                MessageBox.Show($"All mods have been updated.", "Update Buddy - Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        Mod mod = modsToUpdate[currentModIndex];
        string tempFile = Path.Combine(Path.GetTempPath(), $"{mod.Name}_Update.zip");

        progressBar.Visible = true;
        btnUpdate.Enabled = false;
        btnSkip.Enabled = false;

        try
        {
            Progress<int> progress = new(value =>
            {
                if (progressBar.InvokeRequired)
                {
                    progressBar.Invoke(new(() =>
                    {
                        progressBar.Value = value;
                    }));
                }
                else
                {
                    progressBar.Value = value;
                }
            });

            await Downloader.DownloadAsync(mod.UpdateUrl, tempFile, mod.Name, progress);
            await Extractor.ExtractAsync(tempFile, Application.StartupPath, mod.Name, progress);

            currentModIndex++;
            modsUpdated++;
            ShowNextUpdate();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating {mod.Name}: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnUpdate.Enabled = true;
            btnSkip.Enabled = true;
        }
    }

    private void btnSkip_Click(object sender, EventArgs e)
    {
        currentModIndex++;
        ShowNextUpdate();
    }

    private void dismissTipButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.AppSettings.Settings.Remove("ShowTipButton");
        config.AppSettings.Settings.Add("ShowTipButton", false.ToString());
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    }

    private void tipButton_Click(object sender, EventArgs e)
    {
        kofiButton.Visible = true;
        patreonButton.Visible = true;
        closeTipButton.Visible = true;
    }

    private void closeTipButton_Click(object sender, EventArgs e)
    {
        kofiButton.Visible = false;
        patreonButton.Visible = false;
        closeTipButton.Visible = false;
    }

    private void kofiButton_Click(object sender, EventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://ko-fi.com/steveohbyte",
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private void patreonButton_Click(object sender, EventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://patreon.com/steveohbyte",
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}