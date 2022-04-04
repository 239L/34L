using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using NearYouNameSpace.ScriptableObjects;

namespace NearYouNameSpace.Localization
{
    public class LanguageSwitch : MonoBehaviour
    {
        public TMP_Dropdown drop;
        List<string> items;
        List<string> keys;

        [SerializeField] IntValue current;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            while (!LocalizationController.Instance.IsReady)
            {
                yield return null;
            }
            setOptions();

        }

        private void setOptions()
        {
            items = new List<string>();
            keys = new List<string>();
            foreach (LangOptions item in (LangOptions[])Enum.GetValues(typeof(LangOptions)))
            {
                keys.Add(item.ToString());
                items.Add(LocalizationController.Instance.getLocForKey(item.ToString()));

            }
            drop.ClearOptions();
            drop.AddOptions(items);
            if (current.value > -1)
            {
                drop.value = current.value;
            }
            else { current.value = 0; }
        }

        private void updateOptions()
        {
            int i = 0;

            foreach (LangOptions item in (LangOptions[])Enum.GetValues(typeof(LangOptions)))
            {
                drop.options[i].text = LocalizationController.Instance.getLocForKey(item.ToString());

                i++;

            }


        }
        public void onValueChanged(int i)
        {
            LocalizationController.Instance.changeLang(LocalizationController.Instance.checkKey(drop.options[i].text));
            current.value = i;
            StartCoroutine(getnewOptions(i));
        }

        IEnumerator getnewOptions(int i)
        {
            while (!LocalizationController.Instance.IsReady)
            {
                yield return null;
            }
            drop.captionText.text = LocalizationController.Instance.getLocForKey(keys[i]);

            updateOptions();
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}