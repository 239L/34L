using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/IntValue", fileName = "New Int Value")]
    public class IntValue : ScriptableObject
    {
        public int value;
    }
}