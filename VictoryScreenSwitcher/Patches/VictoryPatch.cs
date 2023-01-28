using HarmonyLib;
using MelonLoader;

namespace VictoryScreenSwitcher.Patches;

[HarmonyPatch(typeof(PnlVictory), "PreWarm")]
public class VictoryPatch
{

    private static void Prefix(PnlVictory __instance)
    {
        if (!Save.Settings.IsToggled)
        {
            __instance.pnlControls[0].index = 1;
            __instance.pnlControls[1].index = 0;
        }
        else
        {
            __instance.pnlControls[0].index = 2;
            __instance.pnlControls[2].index = 0;
        }
    }
}