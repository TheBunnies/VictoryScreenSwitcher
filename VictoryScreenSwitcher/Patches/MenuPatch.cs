using Assets.Scripts.UI.Panels;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace VictoryScreenSwitcher.Patches
{
    [HarmonyPatch(typeof(PnlMenu), "Awake")]
    public class MenuPatch
    {
        private static unsafe void Postfix(PnlMenu __instance)
        {
            
            GameObject vSelect = null;
            foreach (Il2CppSystem.Object @object in __instance.transform.parent.parent.Find("Forward"))
            {
                var transform = @object.Cast<Transform>();
                if (transform.name == "PnlVolume")
                {
                    vSelect = transform.gameObject;
                }
            }

            fixed (bool* isToggled = &Save.Settings.IsToggled)
            {
                if (ToggleManager.Toggle == null && vSelect != null)
                {
                    var toggle = Object.Instantiate(vSelect.transform.Find("LogoSetting").Find("Toggles").Find("TglOn").gameObject, __instance.transform);
                    ToggleManager.Toggle = toggle;
                    ToggleManager.SetupToggle(toggle, "Victory screen toggle", new Vector3(-6.8f, -2.65f, 100f), isToggled, "DjMax/Arknights Screen");
                }
            }
        }
    }
}