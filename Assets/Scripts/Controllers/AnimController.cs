using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearYouNameSpace.Controllers
{
    public class AnimController : MonoBehaviour
    {
        [SerializeField]
        private Animator anim;

        public void setAnim(string a, float value)
        {
            anim.SetFloat(a, value);
        }

        public void setAnim(string a, bool value)
        {
            anim.SetBool(a, value);
        }
        public Animator getAnim()
        {
            return anim;
        }

    }
}