using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class HidingSpotController : MonoBehaviour, IAnimator
    {
        [SerializeField]
        AnimController anim;
        bool hidden;

        bool sameInteractables=true;
        bool firstTime = true;

        [SerializeField] Interactable interactable;

        public static bool performed = true;
        public bool Hidden { get { return hidden; } set { hidden = value; } }
        public void playAnimation()
        {
        if (sameInteractables)
        {
            if (firstTime) { anim.setAnim("Open", true);}
            else
            {
                anim.setAnim("Open", hidden);
            }
            performed = true;


            StartCoroutine(waitToClose());
        }
        }


        IEnumerator waitToClose() {
            yield return new WaitForSeconds(0.5f);
         
        
            anim.setAnim("Open", !hidden);
        firstTime = false;

        performed = false;
            
    }
    public void setAnim(bool a)
    {
        if (EventsController.instance.CurrentInteractable == interactable)
        {
            Debug.Log("yep");
            EventsController.setPerformed(true);
            sameInteractables = true;
            hidden = a;
            playAnimation();
            
        }
        else
        {
            sameInteractables = false;
            
        }

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
