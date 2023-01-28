using Assets.Scripts.PeroTools.Nice.Events;
using Assets.Scripts.PeroTools.Nice.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace VictoryScreenSwitcher.Extenstions;

public static class GameObjectExtensions
{
    public static void ToggleOff(this GameObject obj)
    {
        obj.GetComponent<OnToggle>().enabled = false;
        obj.GetComponent<OnToggleOn>().enabled = false;
        obj.GetComponent<OnActivate>().enabled = false;
        obj.GetComponent<VariableBehaviour>().enabled = false;
    }

    public static void SetValue(this Toggle obj, bool val)
    {
        obj.group = null;
        obj.SetIsOnWithoutNotify(val);
    }
}