using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Interact")]

    public class Interact : ScriptableObject
    {
        [SerializeField]
        string name;

        
        public virtual BoolValue getBool() { return new BoolValue(); }

        public virtual void setBool(bool b) { }
        public virtual void Act() { }
    }
}