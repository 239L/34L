using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ExitButton : CustomButton
    {
        public override void onClick()
        {
            base.onClick();
            Application.Quit();
        }
    }
