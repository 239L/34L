using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BoolValue", fileName = "New Bool Value")]
    public class BoolValue : ScriptableObject
    {
        public bool value;
    }
}