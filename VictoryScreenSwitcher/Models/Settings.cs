using Tomlet.Attributes;

namespace VictoryScreenSwitcher.Models;

public struct Settings
{
    [TomlPrecedingComment("Whether the DjMax option is enabled")]
    public bool IsDJMAXToggled;

    [TomlPrecedingComment("Whether the Arknights option is enabled")]
    public bool IsArknightsToggled;

    public Settings(bool isDJMAXToggled, bool isArknightsToggled)
    {
        IsDJMAXToggled = isDJMAXToggled;
        IsArknightsToggled = isArknightsToggled;
    }
}