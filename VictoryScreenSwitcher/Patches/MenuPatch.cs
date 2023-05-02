using Assets.Scripts.UI.Panels;
using UnityEngine;
using UnityEngine.UI;
using static MuseDashMirror.UICreate.ToggleCreate;

namespace VictoryScreenSwitcher.Patches;

internal static class MenuPatch
{
    internal static GameObject DJMAXToggle { get; set; }
    internal static GameObject ArknightsToggle { get; set; }

    internal static void SwitchLanguagesPostfix()
    {
        DJMAXToggle.transform.Find("Txt").GetComponent<Text>().text = "DJMax Screen";
        ArknightsToggle.transform.Find("Txt").GetComponent<Text>().text = "Arknights Screen";
    }

    internal static unsafe void MenuPatchPostfix(PnlMenu __instance)
    {
        var gameObject = new GameObject("VictorySceneSwitcher");
        gameObject.transform.SetParent(__instance.transform);
        gameObject.AddComponent<ToggleGroup>();
        gameObject.GetComponent<ToggleGroup>().allowSwitchOff = true;

        GameObject vSelect = null;
        foreach (var @object in __instance.transform.parent.parent.Find("Forward"))
        {
            var transform = @object.Cast<Transform>();
            if (transform.name == "PnlVolume") vSelect = transform.gameObject;
        }

        fixed (bool* isDJMAXToggled = &Save.Settings.IsDJMAXToggled)
        {
            if (DJMAXToggle == null && vSelect != null)
                DJMAXToggle = CreatePnlMenuToggle("DJMAX screen toggle", isDJMAXToggled, "DJMax Screen", gameObject,
                    gameObject.GetComponent<ToggleGroup>());
        }

        fixed (bool* isArknightsToggled = &Save.Settings.IsArknightsToggled)
        {
            if (ArknightsToggle == null && vSelect != null)
                ArknightsToggle = CreatePnlMenuToggle("Arknights screen toggle", isArknightsToggled, "Arknights Screen",
                    gameObject, gameObject.GetComponent<ToggleGroup>());
        }
    }
}