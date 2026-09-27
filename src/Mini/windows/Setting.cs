using System.IO;
using Mini.Model;
using System.Text.Json;

namespace Mini.Setting;

public static class SettingManager
{
    public static Dictionary<string, string> SettingList { get; set; } = [];
    public static async Task LoadAsync(string path)
    {
        try
        {
            string allText = await File.ReadAllTextAsync(path);
            SettingList.Clear();
            string[] lines = allText.Split(["\r", "\n", "\r\n"], StringSplitOptions.RemoveEmptyEntries);
            string key = "";
            string value = "";
            bool isKey = true;
            foreach(var line in lines)
            {
                key = "";
                value = "";
                foreach(var c in line)
                {
                    if(c == ' ') continue;
                    if(c == '=')
                    {
                        isKey = false;
                        continue;
                    }
                    if(isKey)
                    {
                        key += c;
                    } else
                    {
                        value += c;
                    }
                }
                if(SettingList.TryAdd(key, value)) System.Diagnostics.Debug.WriteLine("[Warn] Load Failed");
                isKey = true;
            }
        } catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[Err] {ex.Message}");
        }
    }

    public static async Task WriteAsync(string path)
    {
        try
        {
            string text = "";
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            foreach(var key in SettingList.Keys)
            {
                SettingList.TryGetValue(key, out string? value);
                text += $"{key}={value}\n";
            }
            string jsonString = JsonSerializer.Serialize(SettingList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
            await File.WriteAllTextAsync(path, text);
        } catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[Err] {ex.Message}");
        }
    }

    public static async Task SaveAsync(string key, string value)
    {
        try {
            SettingList.Add(key, value);
        } catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[Err] {ex.Message}");
        }
    }

    public static bool HaveSetting()
    {
        return SettingList.Count > 0;
    }
}