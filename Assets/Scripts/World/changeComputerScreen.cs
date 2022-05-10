using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeComputerScreen : MonoBehaviour,IAnimator
{
    [SerializeField] AnimController anim;

    public void playAnimation()
    {
        anim.setAnim("OpenApp",true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (EventsController.minigame_icon_pressed) { playAnimation(); }
    }
}
