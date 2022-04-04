using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Interact/WireInteract", fileName = "New Wire Interact")]
    public class WireInteract : Interact
    {
        [SerializeField]
        BoolValue wiresCut;
        public BoolValue WiresCut { get => wiresCut; set => wiresCut = value; }

        public override BoolValue getBool()
        {
            return wiresCut;
        }

        public override void setBool(bool b)
        {
            WiresCut.value = b;
        }
        public override void Act()
        {
            if (!WiresCut.value) WiresCut.value = true;

        }
    }
}