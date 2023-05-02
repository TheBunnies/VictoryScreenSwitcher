using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.GeneralLocalization;
using HarmonyLib;

namespace VictoryScreenSwitcher.Patches;

[HarmonyPatch(typeof(PnlVictory), "InitControl")]
public static class VictoryPatch
{
    private static void Postfix(PnlVictory __instance)
    {
        if (Save.Settings.IsDJMAXToggled)
            __instance.m_CurControls = __instance.pnlControls[1].GetPnlVictoryControls(
                string.Equals(SingletonScriptableObject<LocalizationSettings>.instance.GetActiveOption("Resolution"),
                    "4:3"));
        else if (Save.Settings.IsArknightsToggled)
            __instance.m_CurControls = __instance.pnlControls[2].GetPnlVictoryControls(
                string.Equals(SingletonScriptableObject<LocalizationSettings>.instance.GetActiveOption("Resolution"),
                    "4:3"));
        else
            __instance.m_CurControls = __instance.pnlControls[0].GetPnlVictoryControls(
                string.Equals(SingletonScriptableObject<LocalizationSettings>.instance.GetActiveOption("Resolution"),
                    "4:3"));
    }
}