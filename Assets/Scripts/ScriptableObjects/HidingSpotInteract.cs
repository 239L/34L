
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(menuName = "ScriptableObjects/Interact/HideInteract", fileName = "New Hide Interact")]
    public class HidingSpotInteract : Interact
    {
        [SerializeField]
        BoolValue hide;

        
       
        public BoolValue Hide { get => hide; set => hide = value; }

        public override BoolValue getBool()
        {
            return hide;
        }

        public override void setBool(bool b)
        {
            hide.value = b;
        }
        public override void Act()
        {
            if (hide.value) { hide.value = false; }
            else { hide.value = true; }
           

        }
    }
