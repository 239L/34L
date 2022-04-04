using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/StringValue", fileName = "New String Value")]
    public class StringValue : ScriptableObject
    {
        public string value;
    }
}