using Tomlet.Attributes;

namespace VictoryScreenSwitcher.Models
{
    public struct Settings
    {
        [TomlPrecedingComment("Whether the DjMax or Arknights option is enabled")]
        public bool IsToggled;

        public Settings(bool isToggled)
        {
            IsToggled = isToggled;
        }
    }
}