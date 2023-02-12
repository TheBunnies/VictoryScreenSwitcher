using Assets.Scripts.UI.Panels;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using static MuseDashMirror.UICreate.ToggleCreate;

namespace VictoryScreenSwitcher.Patches
{
    [HarmonyPatch(typeof(PnlMenu), "Awake")]
    internal static class MenuPatch
    {
        internal static GameObject DJMAXToggle { get; set; }
        internal static GameObject ArknightsToggle { get; set; }

        private static unsafe void Postfix(PnlMenu __instance)
        {
            var gameobject = new GameObject("VictorySceneSwitcher");
            gameobject.transform.SetParent(__instance.transform);
            gameobject.AddComponent<ToggleGroup>();
            gameobject.GetComponent<ToggleGroup>().allowSwitchOff = true;

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
                    DJMAXToggle = CreatePnlMenuToggle("DJMAX screen toggle", isDJMAXToggled, "DJMax Screen", gameobject, gameobject.GetComponent<ToggleGroup>());
                }
            }

            fixed (bool* isArknightsToggled = &Save.Settings.IsArknightsToggled)
            {
                if (ArknightsToggle == null && vSelect != null)
                {
                    ArknightsToggle = CreatePnlMenuToggle("Arknights screen toggle", isArknightsToggled, "Arknights Screen", gameobject, gameobject.GetComponent<ToggleGroup>());
                }
            }
        }
    }
}