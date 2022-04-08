using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.GameData;

namespace NearYouNameSpace.GameInterface
{
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
            SceneManagement.SceneController.instance.LoadScene((int)SceneManagement.SceneIndexes.MENU);
        }
    }
}