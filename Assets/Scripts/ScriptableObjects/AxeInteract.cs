using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearYouNameSpace.ScriptableObjects 
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Interact/AxeInteract", fileName = "New Axe Interact")]
    public class AxeInteract : Interact
    {
        [SerializeField]
        BoolValue axeTouched;

        public BoolValue AxeTouched { get => axeTouched; set => axeTouched = value; }

        public override BoolValue getBool() {
            return AxeTouched;
        }

        public override void setBool(bool b)
        {
            AxeTouched.value = b;
        }
        public override void Act() {
            if (!AxeTouched.value) AxeTouched.value = true;

        }


    }
}