using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour, IAnimator
{
    [SerializeField]
    AnimController anim;
    bool wait, set, wrong;
    [SerializeField] int number;
    [SerializeField] FaceInteract interact;

    public static bool animIsFinished = true;
    public void playAnimation()
    {
       // Debug.Log("Animation is played");
        anim.setAnim("Wait", wait);
        anim.setAnim("Set", set);
        anim.setAnim("Wrong",wrong);
        animIsFinished = true;
    }

    

    public void toSet() {
        interact = EventsController.instance.CurrentInteractable.Interact as FaceInteract;
        if (interact.Number == number)
        {
            wait = false;
            set = true;
            wrong = false;
            SoundController.playME(ME.BELL1);
            playAnimation();
        }
    }

    public void toWait() {
        
            wait = true;
            set = false;
            wrong = false;
            playAnimation();
        
        
    }

    public void toWrong()
    {
        SoundController.playME(ME.BELL3);
        wait = false;
            set = false;
            wrong = true;
            playAnimation();
            animIsFinished = false;
            Invoke("toWait", 1f);
            
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
