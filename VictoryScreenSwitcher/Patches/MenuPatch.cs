using Assets.Scripts.UI.Panels;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using static VictoryScreenSwitcher.ToggleManager;

namespace VictoryScreenSwitcher.Patches
{
    [HarmonyPatch(typeof(PnlMenu), "Awake")]
    public class MenuPatch
    {
        private static unsafe void Postfix(PnlMenu __instance)
        {
            __instance.gameObject.AddComponent<ToggleGroup>();
            GameObject vSelect = null;
            foreach (Il2CppSystem.Object @object in __instance.transform.parent.parent.Find("Forward"))
            {
                var transform = @object.Cast<Transform>();
                if (transform.name == "PnlVolume")
                {
                    vSelect = transform.gameObject;
                }
            }

            fixed (bool* isDJMAXToggled = &Save.Settings.IsDJMAXToggled)
            {
                if (DJMAXToggle == null && vSelect != null)
                {
                    var toggle = Object.Instantiate(vSelect.transform.Find("LogoSetting").Find("Toggles").Find("TglOn").gameObject, __instance.transform);
                    DJMAXToggle = toggle;
                    SetupToggle(toggle, "DJMAX screen toggle", new Vector3(-6.8f, -2.65f, 100f), isDJMAXToggled, "DjMax Screen");
                }
            }

            fixed (bool* isArknightsToggled = &Save.Settings.IsArknightsToggled)
            {
                if (ArknightsToggle == null && vSelect != null)
                {
                    var toggle = Object.Instantiate(vSelect.transform.Find("LogoSetting").Find("Toggles").Find("TglOn").gameObject, __instance.transform);
                    ArknightsToggle = toggle;
                    SetupToggle(toggle, "Arknights screen toggle", new Vector3(-6.8f, -3.55f, 100f), isArknightsToggled, "Arknights Screen");
                }
            }

            fixed (bool* isNormalToggled = &Save.Settings.IsNormalToggled)
            {
                if (NormalToggle == null && vSelect != null)
                {
                    var toggle = Object.Instantiate(vSelect.transform.Find("LogoSetting").Find("Toggles").Find("TglOn").gameObject, __instance.transform);
                    NormalToggle = toggle;
                    SetupToggle(toggle, "Normal toggle", new Vector3(-6.8f, -4.45f, 100f), isNormalToggled, "Normal Screen");
                }
            }
        }
    }
}