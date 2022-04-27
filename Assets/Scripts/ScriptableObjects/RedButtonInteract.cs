using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName = "ScriptableObjects/Interact/RedButtonInteract", fileName = "New RedButton Interact")]
    public class RedButtonInteract : Interact
    {
        [SerializeField]
        private BoolValue pressed;

        public BoolValue Pressed { get => pressed; set => pressed = value; }

        public override BoolValue getBool()
        {
            return Pressed;
        }

        public override void Act()
        {
            if (!Pressed.value) Pressed.value = true;

        }

    }
