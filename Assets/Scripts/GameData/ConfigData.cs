using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public class ConfigData
    {
        public int gameResolution;
        public int languageDropdownValue;
        public float masterVolume;
        public float BGMVolume;
        public float SEVolume;

        public string language;


        public ConfigData(ScriptableConfig conf)
        {
            gameResolution = conf.GameResolution.value;
            language = conf.Language.value;
            languageDropdownValue = conf.LanguageDropdownValue.value;
            masterVolume = conf.MasterVolume.value;
            BGMVolume = conf.BGMVolume1.value;
            SEVolume = conf.SEVolume1.value;
        }

    }
