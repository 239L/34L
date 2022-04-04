using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerAbility")]

    public class PlayerAbility : ScriptableObject
    {

        public new string name;
        public float cooldown;
        public float active;



        public virtual void Activate() { }

        public virtual void Deactivate() { }



    }
}