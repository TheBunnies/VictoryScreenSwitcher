using MelonLoader;
using System.IO;
using Tomlet;
using UnityEngine;
using static VictoryScreenSwitcher.ToggleManager;

namespace VictoryScreenSwitcher
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Save.Load();
            LoggerInstance.Msg($"{nameof(VictoryScreenSwitcher)} is loaded!");
        }

        public override void OnApplicationQuit()
        {
            File.WriteAllText(Save.ConfigPath, TomletMain.TomlStringFrom(Save.Settings));
        }

        public override void OnUpdate()
        {
            if (!GameObject.Find("PnlOption") && DJMAXToggle != null)
            {
                DJMAXToggle.SetActive(false);
                ArknightsToggle.SetActive(false);
                NormalToggle.SetActive(false);
            }
            else if (GameObject.Find("PnlOption") && DJMAXToggle != null)
            {
                DJMAXToggle.SetActive(true);
                ArknightsToggle.SetActive(true);
                NormalToggle.SetActive(true);
            }
        }
    }
}