using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.Networking;
using System.Linq;

    public class LocalizationController : MonoBehaviour
    {
        [Header("Strings")]
        private const string FILE_EXT = ".json";
        private const string PREFIX = "local_";


        [SerializeField]
        private StringValue LANG;
        private string LOADEDJSON = "";

        [Header("BOOLS")]
        bool isReady = false;
        public bool IsReady
        {
            get { return isReady; }
        }
        bool fileExists = false;
        bool isLangChangedRuntime = false;

        [Header("DATA")]
        private Dictionary<string, string> dict;
        private LocData loadedData;

        private List<Localized> localized;

        private static LocalizationController instance;

        public static LocalizationController Instance
        {
            get { return instance; }
        }

        IEnumerator switchLang(string lang)
        {
            if (!isLangChangedRuntime)
            {
                isLangChangedRuntime = true;
                fileExists = false;
                isReady = false;
                LANG.value = lang;


                yield return StartCoroutine(loadJSONData());
                isReady = true;
                Localized[] langs = FindObjectsOfType<Localized>();
                for (int i = 0; i < langs.Length; i++)
                {
                    langs[i].attributeText();
                }
                isLangChangedRuntime = false;
                for (int i = 0; i < localized.Count; i++)
                {
                    localized[i].updateText(dict[localized[i].Key]);
                }

            }

        }

        public void changeLang(string lang)
        {
            StartCoroutine(switchLang(lang));
        }

        public string checkKey(string val)
        {
            string a = dict.Where(i => i.Value == val).FirstOrDefault().Key;
            switch (a)
            {
                case "Russian": return "RU";
                case "Danish": return "DA";
                case "Spanish": return "ES";
                case "English":
                default: return "EN";
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else { Destroy(this); }
            DontDestroyOnLoad(this);
        }

        IEnumerator Start()
        {
            if (LANG.value == "") { LANG.value = LocaleHelper.getLang(); }
            yield return StartCoroutine(loadJSONData());
            isReady = true;
            getLocalizedItems();
        }

        public void getLocalizedItems()
        {
            localized = FindObjectsOfType<Localized>().ToList();
        }

        public string getLocForKey(string key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            else
            {
                Debug.Log(key);
                return "Error: No such key " + key;
            }
        }


        IEnumerator loadJSONData()
        {

            getFromResources();
            yield return new WaitUntil(() => fileExists);
            loadedData = JsonUtility.FromJson<LocData>(LOADEDJSON);
            dict = new Dictionary<string, string>(loadedData.LocItems.Count);
            loadedData.LocItems.ForEach(i =>
            {
                try
                {
                    dict.Add(i.key, i.value);
                }
                catch (Exception e) { Debug.LogError(e); }
            }
            );

        }



        private void getFromResources()
        {
            TextAsset text = Resources.Load(PREFIX + LANG.value.ToLower()) as TextAsset;
            if (text == null) { Debug.LogError("No localization file found."); fileExists = false; return; }
            LOADEDJSON = text.ToString(); fileExists = true;

        }


        void Update()
        {

        }
    }
