﻿using MelonLoader;
using MuseDashMirror.CommonPatches;
using System;
using System.IO;
using Tomlet;
using static VictoryScreenSwitcher.Patches.MenuPatch;

namespace VictoryScreenSwitcher
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Save.Load();
            PatchEvents.MenuSelectEvent += new Action<int, int, bool>(DisableToggle);
            LoggerInstance.Msg($"{nameof(VictoryScreenSwitcher)} is loaded!");
        }

        public override void OnDeinitializeMelon()
        {
            File.WriteAllText(Save.ConfigPath, TomletMain.TomlStringFrom(Save.Settings));
        }

        private void DisableToggle(int listIndex, int index, bool isOn)
        {
            if (listIndex == 0 && index == 0 && isOn)
            {
                DJMAXToggle.SetActive(true);
                ArknightsToggle.SetActive(true);
            }
            else
            {
                DJMAXToggle.SetActive(false);
                ArknightsToggle.SetActive(false);
            }
        }
    }
}