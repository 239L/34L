using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.ScriptableObjects;

namespace NearYouNameSpace.GameData
{
    public class ScriptableConfig : MonoBehaviour
    {
        private static ScriptableConfig instance;
        public static ScriptableConfig Instance { get; }

        private void Awake()
        {
            if (instance == null) { instance = this; } else { Destroy(this); }
            DontDestroyOnLoad(this);
            loadConfig(SaveSystem.LoadConfigData());
        }
        // Start is called before the first frame update
        [SerializeField] IntValue gameResolution;

        [SerializeField] IntValue languageDropdownValue;
        [SerializeField] FloatValue masterVolume;
        [SerializeField] FloatValue BGMVolume;
        [SerializeField] FloatValue SEVolume;

        [SerializeField] StringValue language;

        public IntValue GameResolution { get => gameResolution; set => gameResolution = value; }
        public IntValue LanguageDropdownValue { get => languageDropdownValue; set => languageDropdownValue = value; }
        public FloatValue MasterVolume { get => masterVolume; set => masterVolume = value; }
        public FloatValue BGMVolume1 { get => BGMVolume; set => BGMVolume = value; }
        public FloatValue SEVolume1 { get => SEVolume; set => SEVolume = value; }
        public StringValue Language { get => language; set => language = value; }


        public void loadConfig(ConfigData data)
        {
            if (data != null)
            {
                gameResolution.value = data.gameResolution;
                language.value = data.language;
                languageDropdownValue.value = data.languageDropdownValue;
                BGMVolume.value = data.BGMVolume;
                SEVolume.value = data.SEVolume;
                masterVolume.value = data.masterVolume;
            }
        }
    }
}