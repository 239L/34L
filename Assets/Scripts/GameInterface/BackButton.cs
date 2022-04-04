using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NearYouNameSpace.GameData;
namespace NearYouNameSpace.GameInterface
{
    public class BackButton : CustomButton
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject menuButtons;
        [SerializeField] ScriptableConfig sc;

        public override void onClick()
        {
            base.onClick();

            SaveSystem.SaveConfigData(sc);
            menuButtons.SetActive(true);
            panel.SetActive(false);




        }

    }
}