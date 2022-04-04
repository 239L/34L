using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NearYouNameSpace.GameInterface
{
    public class SettingsButton : CustomButton
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject menuButtons;
        // Start is called before the first frame update
        void Start()
        {

        }
        public override void onClick()
        {
            base.onClick();
            panel.SetActive(true);
            menuButtons.SetActive(false);




        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}