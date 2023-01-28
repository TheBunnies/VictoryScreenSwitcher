using System.IO;
using Tomlet;
using VictoryScreenSwitcher.Models;

namespace VictoryScreenSwitcher
{
    public class Save
    {
        private static Settings _default = new(false, false);
        public static readonly string ConfigPath = Path.Combine("UserData", "VictoryScreenSwitcher.cfg");
        public static Settings Settings;

        public static void Load()
        {
            if (!File.Exists(ConfigPath))
            {
                var defaultSettigns = TomletMain.TomlStringFrom(_default);
                File.WriteAllText(ConfigPath, defaultSettigns);
            }

            var data = File.ReadAllText(ConfigPath);
            Settings = TomletMain.To<Settings>(data);
        }
    }
}