using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearYouNameSpace.ScriptableObjects;
namespace NearYouNameSpace.GameInterface
{
    public class WindowedButton : CustomButton
    {
        [SerializeField]
        BoolValue windowed;
        void Awake()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void onClick()
        {
            base.onClick();
            windowed.value = !windowed.value;
            GameResolution.instance.setFullScreen();
            Debug.Log("Fullscreen =" + windowed.value);
            Debug.Log("REAL Fullscreen =" + Screen.fullScreen);
        }

    }
}