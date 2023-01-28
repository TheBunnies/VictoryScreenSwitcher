using Tomlet.Attributes;

namespace VictoryScreenSwitcher.Models
{
    public struct Settings
    {
        [TomlPrecedingComment("Whether the DjMax option is enabled")]
        public bool IsDJMAXToggled;

        [TomlPrecedingComment("Whether the Arknights option is enabled")]
        public bool IsArknightsToggled;

        [TomlPrecedingComment("Whether the Normal option is enabled")]
        public bool IsNormalToggled;

        public Settings(bool isDJMAXToggled, bool isArknightsToggled, bool isNormalToggled)
        {
            IsDJMAXToggled = isDJMAXToggled;
            IsArknightsToggled = isArknightsToggled;
            IsNormalToggled = isNormalToggled;
        }
    }
}