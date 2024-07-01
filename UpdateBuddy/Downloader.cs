namespace UpdateBuddy;

public static class Downloader
{
    public static async Task DownloadAsync(string url, string path, string modName, IProgress<int> progress)
    {
        try
        {
            using HttpClient client = new();
            using HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            long totalBytes = response.Content.Headers.ContentLength ?? 0L;
            Stream stream = await response.Content.ReadAsStreamAsync();
            await using Stream contentStream = stream;
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
            long totalRead = 0L;
            byte[]? buffer = new byte[8192];
            bool isMoreToRead = true;

            do
            {
                int read = await contentStream.ReadAsync(buffer);
                if (read == 0)
                {
                    isMoreToRead = false;
                }
                else
                {
                    await fileStream.WriteAsync(buffer.AsMemory(0, read));
                    totalRead += read;
                    progress?.Report((int)((totalRead * 100) / totalBytes));
                }
            }
            while (isMoreToRead);
        } catch (Exception e)
        {
            MessageBox.Show($"Error downloading {modName}: {e.Message}", "Update Buddy - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}