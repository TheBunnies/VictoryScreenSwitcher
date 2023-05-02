using System.IO;
using Tomlet;
using VictoryScreenSwitcher.Models;

namespace VictoryScreenSwitcher;

public static class Save
{
    private static readonly Settings _default = new(false, false);
    public static readonly string ConfigPath = Path.Combine("UserData", "VictoryScreenSwitcher.cfg");
    public static Settings Settings;

    public static void Load()
    {
        if (!File.Exists(ConfigPath))
        {
            var defaultSettings = TomletMain.TomlStringFrom(_default);
            File.WriteAllText(ConfigPath, defaultSettings);
        }

        var data = File.ReadAllText(ConfigPath);
        Settings = TomletMain.To<Settings>(data);
    }
}