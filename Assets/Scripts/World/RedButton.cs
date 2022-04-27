using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class RedButton : MonoBehaviour, IAnimator
    {
        [SerializeField]
        AnimController anim;

        public void playAnimation()
        {
            anim.setAnim("Pressed", true);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
