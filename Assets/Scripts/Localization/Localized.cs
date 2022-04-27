using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

    public class Localized : MonoBehaviour
    {
        [SerializeField]
        private string key;
        public string Key
        {
            get { return key; }
        }
        [SerializeField]
        TextMeshProUGUI text;
        // Start is called before the first frame update
        IEnumerator Start()
        {
            while (!LocalizationController.Instance.IsReady)
            {
                yield return null;
            }
            attributeText();
        }

        public void attributeText()
        {
            if (text == null)
            {
                text = gameObject.GetComponent<TextMeshProUGUI>();

            }

            try
            {
                text.text = LocalizationController.Instance.getLocForKey(key);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public void updateText(string newVal)
        {
            text.text = newVal;
        }
    }
