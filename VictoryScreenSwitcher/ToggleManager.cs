using System;
using UnityEngine;
using UnityEngine.UI;
using VictoryScreenSwitcher.Extenstions;

namespace VictoryScreenSwitcher
{
    public static class ToggleManager
    {
        public static GameObject Toggle { get; set; }

        public static unsafe void SetupToggle(GameObject toggle, string name, Vector3 position, bool* isEnabled,
            string text)
        {
            toggle.name = name;

            var txt = toggle.transform.Find("Txt").GetComponent<Text>();
            var checkBox = toggle.transform.Find("Background").GetComponent<Image>();
            var checkMark = toggle.transform.Find("Background").GetChild(0).GetComponent<Image>();
            
            toggle.transform.position = position;
            
            toggle.ToggleOff();
            var toggleComp = toggle.GetComponent<Toggle>();
            toggleComp.SetValue(*isEnabled);
            
            toggleComp.onValueChanged.AddListener((Action<bool>) (val =>
            {
                *isEnabled = val;
            }));
            txt.text = text;
            txt.fontSize = 40;
            txt.color = new Color(1, 1, 1, 0.298f);
            var rect = txt.transform.Cast<RectTransform>();
            var vect = rect.offsetMax;
            rect.offsetMax = new Vector2(txt.preferredWidth + 10, vect.y);

            checkBox.color = new Color(60 / 255f, 40 / 255f, 111 / 255f);
            checkMark.color = new Color(103 / 255f, 93 / 255f, 130 / 255f);
        }
    }
}