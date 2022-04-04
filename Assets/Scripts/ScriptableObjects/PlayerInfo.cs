using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerInfo", order = 1)]
    public class PlayerInfo : ScriptableObject
    {
        private float speed = 1.5f;
        public float Speed
        {
            get
            {
                return speed;
            }
            set { speed = value; }
        }
        private Vector2 pos = new Vector2(0.523f, 0.894f);

        public Vector2 Pos
        {
            get
            {
                return pos;
            }
            set { pos = value; }
        }




    }
}