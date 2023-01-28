using System.IO;
using System.Linq;
using MelonLoader;
using Tomlet;
using UnityEngine;
using VictoryScreenSwitcher.Models;

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

            if (!GameObject.Find("PnlOption") && ToggleManager.Toggle != null)
            {
                ToggleManager.Toggle.SetActive(false);
            }
            else if (GameObject.Find("PnlOption") && ToggleManager.Toggle != null)
            {
                ToggleManager.Toggle.SetActive(true);
            }
        }
    }
}