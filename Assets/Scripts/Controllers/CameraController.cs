using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearYouNameSpace.Controllers
{
    public class CameraController : MonoBehaviour
    {

        public Transform inherit;
        public Vector3 pos;
        public bool repeatable;
        private void Update()
        {
            if (repeatable) UpdatePosition();
        }

        void UpdatePosition()
        {
            transform.position = new Vector3(inherit.position.x + pos.x, inherit.position.y + pos.y, pos.z);
        }
    }
}