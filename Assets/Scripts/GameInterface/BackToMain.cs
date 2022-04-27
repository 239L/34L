using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BackToMain : CustomButton
    {
        [SerializeField]
        ScriptableConfig sc;
        private void Start()
        {
            sc = FindObjectOfType<ScriptableConfig>();
        }
        public override void onClick()
        {
            SaveSystem.SaveConfigData(sc);
            base.onClick();
            Pause.canPause = false;
            SceneController.instance.LoadScene((int)SceneIndexes.MENU);
        }
    }
