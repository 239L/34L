using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
