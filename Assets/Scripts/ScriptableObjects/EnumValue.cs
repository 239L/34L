using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/EnumValue", fileName = "New Enum Value")]
    public class EnumValue : ScriptableObject
    {
        [SerializeField]
        private string enumName;

        public string Name { get => name; set => name = value; }
    }
}