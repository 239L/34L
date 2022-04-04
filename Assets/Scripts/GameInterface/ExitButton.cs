using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearYouNameSpace.GameInterface
{
    public class ExitButton : CustomButton
    {
        public override void onClick()
        {
            base.onClick();
            Application.Quit();
        }
    }
}