using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu]
    public class PlayerRun : PlayerAbility
    {
        public FloatValue speed;


        public override void Activate()
        {

            speed.value = 5f;



        }

        public override void Deactivate()
        {

            speed.value = 1.5f;
        }

    }
}